using BankProductsAPI.Application.Auth;
using BankProductsAPI.Application.DTOs.Auth;
using BankProductsAPI.Application.Interfaces;
using BankProductsAPI.Domain.Entities;
using BankProductsAPI.Domain.Enums;
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

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="repository">Класс, содержащий методы для работы с БД по части клиентов.</param>
        public AuthService(IClientRepository repository)
        {
            _repository = repository;
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

            // 3. Генерация токена и его возвращение.
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
            if (client == null) return null;

            // 2. Проверка пароля.
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, client.PasswordHash))
                return null;

            // 3. Геренация токена, если пароль правильный.
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
                issuer: AuthOptions.ISSUER, // Кто выдал токен.
                audience: AuthOptions.AUDIENCE, // Для кого токен.
                claims: claims, // Что внутри токена.
                expires: DateTime.UtcNow.AddMinutes(60), // Сколько живёт токен.
                signingCredentials: new SigningCredentials( // Каким ключом подписан.
                    AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            // 3. Преображение токена в строку.
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
