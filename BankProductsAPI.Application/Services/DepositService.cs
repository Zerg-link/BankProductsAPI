// BankProductsAPI.Application/Services/DepositService.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Deposit;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Domain.Enums;

namespace BankProductsAPI.Application.Services
{
    /// <summary>
    /// Класс, выполняющий бизнес-логику для работы с депозитами.
    /// </summary>
    public class DepositService
    {
        private readonly IDepositRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="repository">Репозиторий, содержащий методы для работы с CRUD (непосредственно методы работы с БД).</param>
        /// <param name="mapper"> Нужен для того, чтобы облегчить передачу данных между классами. Автоматически копирует все атрибуты. </param> 
        public DepositService(IDepositRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод получения депозита по его ID.
        /// </summary>
        /// <param name="id">ID депозита в БД.</param>
        /// <returns> Класс, содержащий информацию о депозите для показа.</returns>
        public async Task<DepositDto?> GetByIdAsync(int id)
        {
            var deposit = await _repository.GetByIdAsync(id);
            return deposit == null ? null : _mapper.Map<DepositDto>(deposit);
        }

        /// <summary>
        /// Метод получения всех депозитов.
        /// </summary>
        /// <returns> Абстрактный контейнер с информацией о депозитах для показа.</returns>
        public async Task<IEnumerable<DepositDto>> GetAllAsync()
        {
            var deposits = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepositDto>>(deposits);
        }

        /// <summary>
        /// Метод создания депозита. Асинхронный.
        /// </summary>
        /// <param name="dto"> Класс, содержащий информацию для создания депозита.</param>
        /// <returns>Класс, показывающий информацию о депозите.</returns>
        public async Task<DepositDto> CreateAsync(CreateDepositDto dto, int clientId)
        {
            var deposit = _mapper.Map<Deposit>(dto);
            deposit.CreatedAt = DateTime.UtcNow;
            deposit.ClientId = clientId;
            deposit.ExpiresAt = DateTime.UtcNow.AddMonths(dto.Duration);
            deposit.Status = DepositStatus.Active;
            await _repository.AddAsync(deposit);
            return _mapper.Map<DepositDto>(deposit);
        }

        /// <summary>
        /// Метод удаления депозита из БД.
        /// </summary>
        /// <param name="id">ID депозита в БД.</param>
        /// <returns> Ничего.</returns>
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        /// <summary>
        /// Асинхронный метод, рассчитывающий доходность выбранного депозита.
        /// </summary>
        /// <param name="id"> ID депозита.</param>
        /// <returns> Null, если нет депозита. Или информацию о доходности депозита.</returns>
        public async Task<DepositYieldDto?> CalculateYieldAsync(int id)
        {
            var deposit = await _repository.GetByIdAsync(id);
            if (deposit == null) 
                return null;

            DepositYieldDto depositYieldDto = new DepositYieldDto();
            depositYieldDto.OriginalAmount = deposit.Amount;
            // Срочный депозит.
            if (deposit.Type == DepositType.Term)
            {
                depositYieldDto.FinalAmount = deposit.Amount * (1 + deposit.InterestRate / 100 * deposit.Duration / 12);
            }

            // Накопительный депозит.
            if (deposit.Type == DepositType.Saving)
            {
                depositYieldDto.FinalAmount = deposit.Amount * (1 + deposit.InterestRate / 100 * deposit.Duration / 12);
            }

            // Депозит с капитализацией.
            if (deposit.Type == DepositType.Capitalized)
            {
                depositYieldDto.FinalAmount = deposit.Amount * (decimal)Math.Pow((double)(1 + deposit.InterestRate / 100 / 12), deposit.Duration);
            }
            depositYieldDto.Profit = depositYieldDto.FinalAmount - depositYieldDto.OriginalAmount;

            return depositYieldDto;
        }
    }
}