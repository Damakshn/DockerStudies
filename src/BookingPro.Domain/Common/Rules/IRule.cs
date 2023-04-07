namespace BookingPro.Domain.Common.Rules
{
    /// <summary>
    /// Правило или ограничение, подлежащее проверке
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Проверка, нарушено ли правило
        /// </summary>
        /// <returns>true, если правило нарушено, иначе false</returns>
        bool IsBroken();

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        string Message { get; }
    }
}
