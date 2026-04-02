// BankProductsAPI/Controllers/ApplicationController.cs


using BankProductsAPI.Application.DTOs.Application;
using BankProductsAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace BankProductsAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы со заявлениями. Принимает HTTP на вход и возвращает HTTP ответ. Такой вот обработчик URL.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] // Определяет доступность контроллера по такому пути.
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        /// <param name="service">Сервис, содержащий бизнес-логику для работы с заявлениями. </param>
        public ApplicationController(ApplicationService service)
        {
            _service = service;
        }


        /// <summary>
        /// Метод получения всех заявлений.
        /// </summary>
        /// <returns>Код страницы 200. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _service.GetAllAsync();
            return Ok(applications);
        }

        /// <summary>
        /// Метод получения определённого заявления.
        /// </summary>
        /// <param name="id"> ID заявления.</param>
        /// <returns>Код страницы 200.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _service.GetByIdAsync(id);
            return application == null ? NotFound() : Ok(application);
        }

        /// <summary>
        /// Метод создания заявления по HTTP запросу.
        /// </summary>
        /// <param name="dto"> Класс с информацией, необходимой для создания заявления.</param>
        /// <returns> Код страницы 201. </returns>
        [HttpPost("{clientId}")]
        public async Task<IActionResult> Create(int clientId, CreateApplicationDto dto)
        {
            var application = await _service.CreateAsync(dto, clientId);
            return CreatedAtAction(nameof(GetById),
                new { id = application.Id }, application);
        }

        /// <summary>
        /// Метод удаления заявления по HTTP запросу.
        /// </summary>
        /// <param name="id">ID заявления, которого удаляем.</param>
        /// <returns> Код 204 - нет контента. </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
