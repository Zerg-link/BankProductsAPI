//  BankProductsAPI.Domain/Enums/DepositTypes.cs


namespace BankProductsAPI.Domain.Enums
{
    /// <summary>
    /// Типы вкладов (депозитов).
    /// </summary>
    public enum DepositType
    {
        Term,           // Срочный.
        Saving,         // Накопительный.
        Capitalized     // С капитализацией.
    }
}
