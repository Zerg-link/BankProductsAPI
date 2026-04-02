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
    }
}