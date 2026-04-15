// BankProductsAPI/Domain/Enums/ApplicationStateMachine.cs


namespace BankProductsAPI.Domain.Enums
{
    /// <summary>
    /// Класс, осуществяющий переход статусов заявление из одного типа в другой.
    /// </summary>
    public static class ApplicationStateMachine
    {
        private static readonly Dictionary<ApplicationStatus, List<ApplicationStatus>> _transitions = new()
    {
        { ApplicationStatus.Created, new List<ApplicationStatus> { ApplicationStatus.UnderReview } },
        { ApplicationStatus.UnderReview, new List<ApplicationStatus> { ApplicationStatus.Approved, ApplicationStatus.Rejected } }
    };


        /// <summary>
        /// Метод, проверяющий возможность перехода из одного состояния в другое.
        /// </summary>
        /// <param name="from">Статус до.</param>
        /// <param name="to">Статус после.</param>
        /// <returns>Можно ли совершить переход или нельзя.</returns>
        public static bool CanTransition(ApplicationStatus from, ApplicationStatus to)
        {
            if (_transitions.TryGetValue(from, out var possibleStatuses))
                return possibleStatuses.Contains(to);

            return false;
        }
    };

}
