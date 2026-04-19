using BankProductsAPI.Application.Auth;
using BankProductsAPI.Application.DTOs.Auth;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace BankProductsAPI.Application.Services
{
    /// <summary>
    /// Класс, содержащий методы с бизнес-логикой для авторизации.
    /// </summary>
    public class AuthService
    {
        private readonly IClientRepository _repository;
        private readonly ILogger<AuthService> _logger;
        private readonly AuthOptions _authOptions;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="repository">Класс, содержащий методы для работы с БД по части клиентов.</param>
        /// <param name="authOptions">Параметры авторизации. Берёт их из appsettings.json.</param>
        /// <param name="logger">Логгер для... сохранения логов.</param>
        public AuthService(IClientRepository repository, ILogger<AuthService> logger, AuthOptions authOptions)
        {
            _repository = repository;
            _logger = logger;
            _authOptions = authOptions;
        }

        /// <summary>
        /// Метод асинхронный для регистрации.
        /// </summary>
        /// <param name="dot">Класс, описывающий, что нужно ввести для регистрации.</param>
        /// <returns>Класс, содержащий токен.</returns>
        public async Task<TokenDto> RegisterAsync(RegisterDto dot)
        {
            // 1. Создание клиента.
            var client = new Client
            {
                FirstName = dot.FirstName,
                LastName = dot.LastName,
                Email = dot.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dot.Password),
                RegisterDate = DateTime.UtcNow,
                CreditRating = 50,
                Role = Role.Client,
            };

            // 2. Сохранение клиента в базе данных.
            await _repository.AddAsync(client);

            // 3. Генерация токена и его возвращение. Логгирование.
            _logger.LogInformation("Клиент зарегистрирован: {Email}.", dot.Email);
            return new TokenDto { Token = GenerateToken(client) };
        }

        /// <summary>
        /// Метод асинхронный для входа в аккаунт.
        /// </summary>
        /// <param name="dto">Класс, описывающий - что нужно ввести для входа.</param>
        /// <returns>Класс, содержащий токен.</returns>
        public async Task<TokenDto?> LoginAsync(LoginDto dto)
        {
            // 1. Поиск клиента по email.
            var client = await _repository.GetByEmailAsync(dto.Email);
            if (client == null)
            {
                _logger.LogWarning("Ошибка входа: email {Email} не был найден.", dto.Email);
                return null;
            }

            // 2. Проверка пароля.
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, client.PasswordHash))
            {
                _logger.LogWarning("Ошибка входа: неправильный пароль для {Email}", dto.Email);
                return null;
            }

            // 3. Геренация токена, если пароль правильный.
            _logger.LogInformation("Клиент {Email}: вход выполнен.", dto.Email);
            return new TokenDto { Token = GenerateToken(client) };
        }

        /// <summary>
        /// Метод генерации токена.
        /// </summary>
        /// <param name="client">Класс, описывающий клиента.</param>
        /// <returns>Строка-токен.</returns>
        private string GenerateToken(Client client)
        {
            // 1. Данные токена (данные клиента).
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
                new Claim(ClaimTypes.Email, client.Email),
                new Claim(ClaimTypes.Role, client.Role.ToString())
            };

            // 2. Создание токена.
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer, // Кто выдал токен.
                audience: _authOptions.Audience, // Для кого токен.
                claims: claims, // Что внутри токена.
                expires: DateTime.UtcNow.AddMinutes(60), // Сколько живёт токен.
                signingCredentials: new SigningCredentials( // Каким ключом подписан.
                    _authOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            // 3. Преображение токена в строку.
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
