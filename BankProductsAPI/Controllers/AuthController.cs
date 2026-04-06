// BankProductsAPI/Controllers/AuthController.cs


using Microsoft.AspNetCore.Mvc;
using BankProductsAPI.Application.DTOs.Auth;
using BankProductsAPI.Application.Services;

namespace BankProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        /// <param name="authService">Класс-сервис с методами для работы с авторизацией.</param>
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Метод регистрации. Асинхронный.
        /// </summary>
        /// <param name="dto">Класс с вводимой информацией для регистрации.</param>
        /// <returns>Код страницы.</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(token);
        }


        /// <summary>
        /// Метод входа в аккаунт. Асинхронный.
        /// </summary>
        /// <param name="dto">Класс с вводимой информацией для входа в аккаунт.</param>
        /// <returns>Код страницы.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized("Неверный email или пароль");

            return Ok(token);
        }
    }
}
