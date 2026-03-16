//  BankProductsAPI.Domain/Enums/CreditStatus.cs


namespace BankProductsAPI.Domain.Enums
{
    /// <summary>
    /// Виды статусов кредита.
    /// </summary>
    public enum CreditStatus
    {
        Active,     // Выплачивается.
        PaidOff,    // Выплачен.
        Overdue     // Пропущен платёж.
    }
}
