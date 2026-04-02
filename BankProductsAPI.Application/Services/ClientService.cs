// BankProductsAPI.Application/Services/ClientService.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Client;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Services
{
    /// <summary>
    /// Класс, выполняющий бизнес-логику для работы с клиентами.
    /// </summary>
    public class ClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="repository">Репозиторий, содержащий методы для работы с CRUD (непосредственно методы работы с БД).</param>
        /// <param name="mapper"> Нужен для того, чтобы облегчить передачу данных между классами. Автоматически копирует все атрибуты. </param>
        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод получения клиента по его ID.
        /// </summary>
        /// <param name="id">ID клиента в БД.</param>
        /// <returns> Класс, содержащий информацию о клиенте для показа.</returns>
        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            return client == null ? null : _mapper.Map<ClientDto>(client);
        }

        /// <summary>
        /// Метод получения всех клиентов.
        /// </summary>
        /// <returns> Абстрактный контейнер с информацией о клиентах для показа.</returns>
        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        /// <summary>
        /// Метод создания клиента. Асинхронный.
        /// </summary>
        /// <param name="dto"> Класс, содержащий информацию для создания клиента.</param>
        /// <returns>Класс, показывающий информацию о клиенте.</returns>
        public async Task<ClientDto> CreateAsync(CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            client.RegisterDate = DateTime.UtcNow;
            client.CreditRating = 50;
            client.PasswordHash = dto.Password;
            await _repository.AddAsync(client);
            return _mapper.Map<ClientDto>(client);
        }

        /// <summary>
        /// Метод удаления клиента из БД.
        /// </summary>
        /// <param name="id">ID клиента в БД.</param>
        /// <returns> Ничего.</returns>
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
