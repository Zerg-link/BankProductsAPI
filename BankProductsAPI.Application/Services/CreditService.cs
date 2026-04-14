// BankProductsAPI.Application/Services/CreditService.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Credit;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.Services
{
    /// <summary>
    /// Класс, отвечающий за то, что используя методы из репозитория, осуществляет бизнес логику приложения. Работает с кредитами.
    /// </summary>
    public class CreditService
    {
        private readonly ICreditRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="repository">Репозиторий, содержащий методы для работы с CRUD (непосредственно методы работы с БД).</param>
        /// <param name="mapper">Нужен для того, чтобы облегчить передачу данных между классами. Автоматически копирует все атрибуты.</param>
        public CreditService(ICreditRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод получения кредита по его ID.
        /// </summary>
        /// <param name="id">ID кредита в БД.</param>
        /// <returns> Класс, содержащий информацию о кредите для показа.</returns>
        public async Task<CreditDto?> GetByIdAsync(int id)
        {
            var credit = await _repository.GetByIdAsync(id);
            return credit == null ? null : _mapper.Map<CreditDto>(credit);
        }

        /// <summary>
        /// Метод получения всех кредитов.
        /// </summary>
        /// <returns> Абстрактный контейнер с информацией о кредитах для показа.</returns>
        public async Task<IEnumerable<CreditDto>> GetAllAsync()
        {
            var credits = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CreditDto>>(credits);
        }

        /// <summary>
        /// Метод создания кредита. Асинхронный.
        /// </summary>
        /// <param name="dto"> Класс, содержащий информацию для создания кредита.</param>
        /// <returns>Класс, показывающий информацию о кредите.</returns>
        public async Task<CreditDto> CreateAsync(CreateCreditDto dto, int clientId)
        {
            var credit = _mapper.Map<Credit>(dto);
            credit.CreatedAt = DateTime.UtcNow;
            credit.Status = CreditStatus.Active;
            credit.ClientId = clientId;
            credit.ExpiresAt = DateTime.UtcNow.AddMonths(dto.Duration);
            credit.MonthlyPayment = CalculateMonthlyPayment(dto.Amount, dto.InterestRate, dto.Duration);

            await _repository.AddAsync(credit);
            return _mapper.Map<CreditDto>(credit);
        }

        /// <summary>
        /// Метод удаления кредита из БД.
        /// </summary>
        /// <param name="id">ID кредита в БД.</param>
        /// <returns> Ничего.</returns>
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        /// <summary>
        /// Метод, который просчитывает финансовую часть кредита (ежемесячный платеж, итоговую переплату и т.д.)
        /// </summary>
        /// <param name="id">ID кредита.</param>
        /// <returns>Null или финансовую информацию о кредите.</returns>
        public async Task<CreditCalculationDto?> CalculateAsync(int id)
        {
            var credit = await _repository.GetByIdAsync(id);
            if (credit == null) return null;

            var monthlyPayment = CalculateMonthlyPayment(credit.Amount, credit.InterestRate, credit.Duration);

            return new CreditCalculationDto
            {
                OriginalAmount = credit.Amount,
                MonthlyPayment = monthlyPayment,
                TotalAmount = monthlyPayment * credit.Duration,
                Overpayment = monthlyPayment * credit.Duration - credit.Amount
            };
        }

        /// <summary>
        /// Метод расчета ежемесячного платежа для кредитки.
        /// </summary>
        /// <param name="amount">Сумма, на которую взяли кредит.</param>
        /// <param name="interestRate">n-ое количество процентов годовых кредита</param>
        /// <param name="duration">Количество месяцев для кредитки.</param>
        /// <returns></returns>
        private decimal CalculateMonthlyPayment(decimal amount, decimal interestRate, int duration)
        {
            if (interestRate == 0)
                return amount / duration;

            var monthlyRate = interestRate / 12 / 100;
            var pow = (decimal)Math.Pow((double)(1 + monthlyRate), duration);

            return amount * monthlyRate * pow / (pow - 1);
        }
    }
}