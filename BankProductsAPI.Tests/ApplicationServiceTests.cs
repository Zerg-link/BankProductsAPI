// BankProductsAPI.Tests/ApplicationServiceTests.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Application;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Application.Services;
using BankProductsAPI.Domain.Enums;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BankProductsAPI.Tests
{
    /// <summary>
    /// Класс, содержащий тесты для тестирования бизнес-логики заявлений.
    /// </summary>
    public class ApplicationServiceTests
    {
        // Объявление временных сущностей-имитаций для тестирования.
        private readonly Mock<IApplicationRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<ApplicationService>> _loggerMock;
        private readonly ApplicationService _service;

        // Конструктор.
        public ApplicationServiceTests()
        {
            _repositoryMock = new Mock<IApplicationRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<ApplicationService>>();
            _service = new ApplicationService(
                _repositoryMock.Object,
                _mapperMock.Object,
                _loggerMock.Object);
        }

        // Тест: успешная смена статуса (Created -> Approved).
        [Fact]
        public async Task ChangeStatusAsync_ValidTransition_ReturnsUpdatedApplication()
        {
            // Подготовка данных.
            var application = new BankProductsAPI.Domain.Entities.Application
            {
                Id = 1,
                ClientId = 10,
                Status = ApplicationStatus.UnderReview,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var dto = new ChangeApplicationStatusDto
            {
                NewStatus = ApplicationStatus.Approved,
                ManagerComment = "Одобрено."
            };

            var expectedDto = new ApplicationDto
            {
                Id = 1,
                Status = ApplicationStatus.Approved
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(application);

            _mapperMock
                .Setup(m => m.Map<ApplicationDto>(It.IsAny<BankProductsAPI.Domain.Entities.Application>()))
                .Returns(expectedDto);

            // Вызов метода.
            var result = await _service.ChangeStatusAsync(1, dto);

            // Проверка результатов.
            result.Should().NotBeNull();
            result!.Status.Should().Be(ApplicationStatus.Approved);
        }

        // Тест: невалидный переход статуса (Rejected -> Approved) — должен бросить исключение.
        [Fact]
        public async Task ChangeStatusAsync_InvalidTransition_ThrowsException()
        {
            // Подготовка данных: заявление уже отклонено.
            var application = new BankProductsAPI.Domain.Entities.Application
            {
                Id = 2,
                ClientId = 10,
                Status = ApplicationStatus.Rejected,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var dto = new ChangeApplicationStatusDto
            {
                NewStatus = ApplicationStatus.Approved,
                ManagerComment = "Попытка одобрить отклонённое."
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(2))
                .ReturnsAsync(application);

            // Вызов метода — ожидаем исключение.
            var act = () => _service.ChangeStatusAsync(2, dto);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        // Тест: заявление не найдено — возвращает null.
        [Fact]
        public async Task ChangeStatusAsync_ApplicationNotFound_ReturnsNull()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(999))
                .ReturnsAsync((BankProductsAPI.Domain.Entities.Application?)null);

            var dto = new ChangeApplicationStatusDto
            {
                NewStatus = ApplicationStatus.Approved,
                ManagerComment = "Тест."
            };

            var result = await _service.ChangeStatusAsync(999, dto);

            result.Should().BeNull();
        }
    }
}