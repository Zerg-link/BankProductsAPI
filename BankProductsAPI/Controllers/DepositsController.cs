// BankProductsAPI/Controllers/DepositsController.cs


using BankProductsAPI.Application.DTOs.Deposit;
using BankProductsAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BankProductsAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы со вкладами. Принимает HTTP на вход и возвращает HTTP ответ. Такой вот обработчик URL.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")] // Определяет доступность контроллера по такому пути.
    public class DepositsController : ControllerBase
    {
        private readonly DepositService _service;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        /// <param name="service">Сервис, содержащий бизнес-логику для работы с депозитами. </param>
        public DepositsController(DepositService service)
        {
            _service = service;
        }


        /// <summary>
        /// Метод получения всех депозитов.
        /// </summary>
        /// <returns>Код страницы 200. </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deposits = await _service.GetAllAsync();
            return Ok(deposits);
        }

        /// <summary>
        /// Метод получения определённого депозита.
        /// </summary>
        /// <param name="id"> ID депозита.</param>
        /// <returns>Код страницы 200.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var deposit = await _service.GetByIdAsync(id);
            return deposit == null ? NotFound() : Ok(deposit);
        }

        /// <summary>
        /// Метод создания депозита по HTTP запросу.
        /// </summary>
        /// <param name="dto"> Класс с информацией, необходимой для создания депозита.</param>
        /// <returns> Код страницы 201. </returns>
        [HttpPost("{clientId}")]
        public async Task<IActionResult> Create(int clientId, CreateDepositDto dto)
        {
            var deposit = await _service.CreateAsync(dto, clientId);
            return CreatedAtAction(nameof(GetById),
                new { id = deposit.Id }, deposit);
        }

        /// <summary>
        /// Метод удаления депозита по HTTP запросу.
        /// </summary>
        /// <param name="id">ID депозита, которого удаляем.</param>
        /// <returns> Код 204 - нет контента. </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Метод расчета выгоды от депозита по HTTP запросу.
        /// </summary>
        /// <param name="id">ID депозита.</param>
        /// <returns>Код страницы с информацией по финасовой части депозита.</returns>
        [HttpGet("{id}/yield")]
        public async Task<IActionResult> CalculateYield(int id)
        {
            var depositYieldDto = await _service.CalculateYieldAsync(id);
            if (depositYieldDto == null) return NotFound();
            return Ok(depositYieldDto);
        }
    }
}
