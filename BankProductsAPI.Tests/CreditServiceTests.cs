// BankProductsAPI.Tests/CreditServiceTests.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Credit;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Application.Services;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Domain.Enums;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BankProductsAPI.Tests
{
    /// <summary>
    /// Класс, содержащий тесты для тестирования бизнес-логики кредитов.
    /// </summary>
    public class CreditServiceTests
    {
        // Объявление временных сущностей-имитаций для тестирования.
        private readonly Mock<ICreditRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<CreditService>> _loggerMock;
        private readonly CreditService _service;

        // Конструктор, что вызывает все эти временные сущности для каждого из тестов.
        public CreditServiceTests()
        {
            _repositoryMock = new Mock<ICreditRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<CreditService>>();
            _service = new CreditService(
                _repositoryMock.Object,
                _mapperMock.Object,
                _loggerMock.Object);
        }

        // Тест: расчёт кредита с нормальной ставкой.
        [Fact]
        public async Task CalculateAsync_WithValidCredit_ReturnsCorrectCalculation()
        {
            // Подготовка данных.
            var credit = new Credit
            {
                Id = 1,
                Amount = 100000,
                InterestRate = 12,
                Duration = 12,
                Status = CreditStatus.Active
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(credit);

            // Вызов метода.
            var result = await _service.CalculateAsync(1);

            // Проверка результатов.
            result.Should().NotBeNull();
            result!.OriginalAmount.Should().Be(100000);
            result.MonthlyPayment.Should().BeGreaterThan(0);
            result.TotalAmount.Should().BeGreaterThan(100000);
            result.Overpayment.Should().BeGreaterThan(0);
        }

        // Тест: кредит не найден.
        [Fact]
        public async Task CalculateAsync_CreditNotFound_ReturnsNull()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(999))
                .ReturnsAsync((Credit?)null);

            var result = await _service.CalculateAsync(999);

            result.Should().BeNull();
        }

        // Тест: нулевая процентная ставка — простое деление без процентов.
        [Fact]
        public async Task CalculateAsync_ZeroInterestRate_ReturnsFlatPayment()
        {
            var credit = new Credit
            {
                Id = 2,
                Amount = 120000,
                InterestRate = 0,
                Duration = 12,
                Status = CreditStatus.Active
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(2))
                .ReturnsAsync(credit);

            var result = await _service.CalculateAsync(2);

            result.Should().NotBeNull();
            result!.MonthlyPayment.Should().Be(10000); // 120000 / 12
            result.Overpayment.Should().Be(0);
        }
    }
}