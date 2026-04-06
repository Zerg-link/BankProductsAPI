// BankProductsAPI/Application/DTOs/Auth/LoginDto.cs


namespace BankProductsAPI.Application.DTOs.Auth
{
    /// <summary>
    /// Класс, описывающий, какие данные мы должны ввести для входа в аккаунт.
    /// </summary>
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
