// BankProductsAPI.Tests/DepositServiceTests.cs


using AutoMapper;
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
    /// Класс, содержащий тесты для тестирования бизнес-логики вкладов.
    /// </summary>
    public class DepositServiceTests
    {
        // Объявление временных сущностей-имитаций для тестирования.
        private readonly Mock<IDepositRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<DepositService>> _loggerMock;
        private readonly DepositService _service;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DepositServiceTests()
        {
            _repositoryMock = new Mock<IDepositRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<DepositService>>();
            _service = new DepositService(
                _repositoryMock.Object,
                _mapperMock.Object,
                _loggerMock.Object);
        }

        // Тест: расчёт доходности срочного вклада.
        [Fact]
        public async Task CalculateYieldAsync_TermDeposit_ReturnsCorrectYield()
        {
            // Подготовка данных: 100.000 руб., 12% годовых, 12 месяцев, срочный.
            var deposit = new Deposit
            {
                Id = 1,
                Amount = 100000,
                InterestRate = 12,
                Duration = 12,
                Type = DepositType.Term
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(deposit);

            var result = await _service.CalculateYieldAsync(1);

            // Срочный: FinalAmount = 100000 * (1 + 12/100 * 12/12) = 100000 * 1.12 = 112000
            result.Should().NotBeNull();
            result!.OriginalAmount.Should().Be(100000);
            result.FinalAmount.Should().Be(112000);
            result.Profit.Should().Be(12000);
        }

        // Тест: расчёт доходности накопительного вклада.
        [Fact]
        public async Task CalculateYieldAsync_SavingDeposit_ReturnsCorrectYield()
        {
            // Подготовка данных: 200.000 руб., 10% годовых, 6 месяцев, накопительный.
            var deposit = new Deposit
            {
                Id = 2,
                Amount = 200000,
                InterestRate = 10,
                Duration = 6,
                Type = DepositType.Saving
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(2))
                .ReturnsAsync(deposit);

            var result = await _service.CalculateYieldAsync(2);

            // Накопительный: FinalAmount = 200000 * (1 + 10/100 * 6/12) = 200000 * 1.05 = 210000
            result.Should().NotBeNull();
            result!.OriginalAmount.Should().Be(200000);
            result.FinalAmount.Should().Be(210000);
            result.Profit.Should().Be(10000);
        }

        // Тест: расчёт доходности вклада с капитализацией.
        [Fact]
        public async Task CalculateYieldAsync_CapitalizedDeposit_ReturnsCorrectYield()
        {
            // Подготовка данных: 100.000 руб., 12% годовых, 12 месяцев, с капитализацией.
            var deposit = new Deposit
            {
                Id = 3,
                Amount = 100000,
                InterestRate = 12,
                Duration = 12,
                Type = DepositType.Capitalized
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(3))
                .ReturnsAsync(deposit);

            var result = await _service.CalculateYieldAsync(3);

            // С капитализацией: FinalAmount = 100000 * (1 + 0.12/12)^12 = 100000 * 1.01^12 = 112682.50
            result.Should().NotBeNull();
            result!.OriginalAmount.Should().Be(100000);
            result.FinalAmount.Should().BeGreaterThan(112000);  // Больше, чем у срочного (сложный процент).
            result.Profit.Should().BeGreaterThan(12000);
        }

        // Тест: вклад не найден.
        [Fact]
        public async Task CalculateYieldAsync_DepositNotFound_ReturnsNull()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(999))
                .ReturnsAsync((Deposit?)null);

            var result = await _service.CalculateYieldAsync(999);

            result.Should().BeNull();
        }
    }
}