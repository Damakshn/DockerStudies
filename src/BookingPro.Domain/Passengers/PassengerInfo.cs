using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPro.Domain.Passengers
{
    public class PassengerInfo
    {
        public string PassengerId { get; set; }

        public string Name { get; set; }

        public ContactData ContactData { get; set; }

    }
}
