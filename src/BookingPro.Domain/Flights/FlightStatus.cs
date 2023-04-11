namespace BookingPro.Domain.Flights
{
    /// <summary>
    /// Статус рейса
    /// </summary>
    public enum FlightStatus
    {
        /// <summary>
        /// Рейс доступен для бронирования. Это происходит за месяц до плановой даты вылета; до этого запись о рейсе не существует в базе данных.
        /// </summary>
        Scheduled,

        /// <summary>
        /// Рейс доступен для регистрации (за сутки до плановой даты вылета) и не задержан.
        /// </summary>
        OnTime,

        /// <summary>
        /// Рейс доступен для регистрации (за сутки до плановой даты вылета), но задержан.
        /// </summary>
        Delayed,

        /// <summary>
        /// Самолет уже вылетел и находится в воздухе.
        /// </summary>
        Departed,

        /// <summary>
        /// Самолет прибыл в пункт назначения.
        /// </summary>
        Arrived,

        /// <summary>
        /// Рейс отменён.
        /// </summary>
        Cancelled
    }
}
