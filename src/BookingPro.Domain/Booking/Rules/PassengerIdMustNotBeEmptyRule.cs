using BookingPro.Domain.Common.Rules;

namespace BookingPro.Domain.Booking.Rules
{
    public class PassengerIdMustNotBeEmptyRule : IRule
    {
        private readonly string _passengerId;

        public PassengerIdMustNotBeEmptyRule(string passengerId)
        {
            _passengerId = passengerId;
        }

        public string Message => "Код пассажира должен быть заполнен";

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(_passengerId);
        }
    }
}
