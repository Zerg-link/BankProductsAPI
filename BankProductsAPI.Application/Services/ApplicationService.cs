// BankProductsAPI.Application/Services/ApplicationService.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Application;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Enums;


namespace BankProductsAPI.Application.Services
{
    /// <summary>
    /// Класс, отвечающий за то, что используя методы из репозитория, осуществляет бизнес логику приложения. Работает с заявлениями.
    /// </summary>
    public class ApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="repository">Репозиторий, содержащий методы для работы с CRUD (непосредственно методы работы с БД).</param>
        /// <param name="mapper">Нужен для того, чтобы облегчить передачу данных между классами. Автоматически копирует все атрибуты.</param>
        public ApplicationService(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод получения заявки по его ID.
        /// </summary>
        /// <param name="id">ID заявки в БД.</param>
        /// <returns> Класс, содержащий информацию о заявке для показа.</returns>
        public async Task<ApplicationDto?> GetByIdAsync(int id)
        {
            var application = await _repository.GetByIdAsync(id);
            return application == null ? null : _mapper.Map<ApplicationDto>(application);
        }

        /// <summary>
        /// Метод получения всех заявлений.
        /// </summary>
        /// <returns> Абстрактный контейнер с информацией о заявлениях для показа.</returns>
        public async Task<IEnumerable<ApplicationDto>> GetAllAsync()
        {
            var applications = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ApplicationDto>>(applications);
        }

        /// <summary>
        /// Метод создания заявления. Асинхронный.
        /// </summary>
        /// <param name="dto"> Класс, содержащий информацию для создания заявления.</param>
        /// <returns>Класс, показывающий информацию о заявлении.</returns>
        public async Task<ApplicationDto> CreateAsync(CreateApplicationDto dto, int clientId)
        {
            var application = _mapper.Map<BankProductsAPI.Domain.Entities.Application>(dto);
            application.CreatedAt = DateTime.UtcNow;
            application.ClientId = clientId;
            application.Status = ApplicationStatus.Created;
            application.UpdatedAt = DateTime.UtcNow;

            await _repository.AddAsync(application);
            return _mapper.Map<ApplicationDto>(application);
        }

        /// <summary>
        /// Метод удаления заявления из БД.
        /// </summary>
        /// <param name="id">ID заявления в БД.</param>
        /// <returns> Ничего.</returns>
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        /// <summary>
        /// Метод, изменяющий статус заявления на новый.
        /// </summary>
        /// <param name="id">ID заявления.</param>
        /// <param name="dto">Контейнер с информацией об изменении статуса заявления.</param>
        /// <returns></returns>
        public async Task<ApplicationDto?> ChangeStatusAsync(int id, ChangeApplicationStatusDto dto)
        {
            var application = await _repository.GetByIdAsync(id);
            if (application == null) return null;

            if (!ApplicationStateMachine.CanTransition(application.Status, dto.NewStatus))
                throw new InvalidOperationException(
                    $"Нельзя перевести заявление из {application.Status} в {dto.NewStatus}");

            application.Status = dto.NewStatus;
            application.ManagerComment = dto.ManagerComment;
            application.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(application);

            return _mapper.Map<ApplicationDto>(application);
        }
    }
}