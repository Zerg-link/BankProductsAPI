// BankProductsAPI/Controllers/ClientsController.cs


using BankProductsAPI.Application.DTOs.Client;
using BankProductsAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace BankProductsAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с клиентами. Принимает HTTP на вход и возвращает HTTP ответ. Такой вот обработчик URL.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] // Определяет доступность контроллера по такому пути.
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _service;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        /// <param name="service">Сервис, содержащий бизнес-логику для работы с клиентами. </param>
        public ClientsController(ClientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Метод получения всех клиентов.
        /// </summary>
        /// <returns>Код страницы 200. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAllAsync();
            return Ok(clients);
        }

        /// <summary>
        /// Метод получения определённого клиента.
        /// </summary>
        /// <param name="id"> ID клиента.</param>
        /// <returns>Код страницы 200.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _service.GetByIdAsync(id);
            return client == null ? NotFound() : Ok(client);
        }

        /// <summary>
        /// Метод создания клиента по HTTP запросу.
        /// </summary>
        /// <param name="dto"> Класс с информацией, необходимой для создания клиента.</param>
        /// <returns> Код страницы 201. </returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto dto)
        {
            var client = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById),
                new { id = client.Id }, client);
        }

        /// <summary>
        /// Метод удаления клиента по HTTP запросу.
        /// </summary>
        /// <param name="id">ID клиента, которого удаляем.</param>
        /// <returns> Код 204 - нет контента. </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}