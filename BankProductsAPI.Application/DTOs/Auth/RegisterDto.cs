// BankProductsAPI/Application/DTOs/Auth/RegisterDto.cs


namespace BankProductsAPI.Application.DTOs.Auth
{

    /// <summary>
    /// Класс, описывающий, какие данные мы должны ввести для регистрации.
    /// </summary>
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
