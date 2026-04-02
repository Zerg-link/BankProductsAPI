// BankProductsAPI/Controllers/CreditsController.cs


using BankProductsAPI.Application.DTOs.Credit;
using BankProductsAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace BankProductsAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с кредитами. Принимает HTTP на вход и возвращает HTTP ответ. Такой вот обработчик URL.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] // Определяет доступность контроллера по такому пути.
    public class CreditsController : ControllerBase
    {
        private readonly CreditService _service;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        /// <param name="service">Сервис, содержащий бизнес-логику для работы с кредитами. </param>
        public CreditsController(CreditService service) {
            _service = service;
        }


        /// <summary>
        /// Метод получения всех кредитов.
        /// </summary>
        /// <returns>Код страницы 200. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var credits = await _service.GetAllAsync();
            return Ok(credits);
        }

        /// <summary>
        /// Метод получения определённого кредита.
        /// </summary>
        /// <param name="id"> ID кредита.</param>
        /// <returns>Код страницы 200.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var credit = await _service.GetByIdAsync(id);
            return credit == null ? NotFound() : Ok(credit);
        }

        /// <summary>
        /// Метод создания кредита по HTTP запросу.
        /// </summary>
        /// <param name="dto"> Класс с информацией, необходимой для создания кредита.</param>
        /// <returns> Код страницы 201. </returns>
        [HttpPost("{clientId}")]
        public async Task<IActionResult> Create(int clientId, CreateCreditDto dto)
        {
            var credit = await _service.CreateAsync(dto, clientId);
            return CreatedAtAction(nameof(GetById),
                new { id = credit.Id }, credit);
        }

        /// <summary>
        /// Метод удаления кредита по HTTP запросу.
        /// </summary>
        /// <param name="id">ID кредита, которого удаляем.</param>
        /// <returns> Код 204 - нет контента. </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
