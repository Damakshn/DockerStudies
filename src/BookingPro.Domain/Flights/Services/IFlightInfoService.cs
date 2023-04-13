using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPro.Domain.Flights.Services
{
    /// <summary>
    /// Получает справочную информацию о рейсах
    /// </summary>
    public interface IFlightInfoService
    {
        /// <summary>
        /// Получить информацию о рейсах по списку ID.
        /// </summary>
        /// <param name="flightIds">ID рейсов</param>
        /// <returns>Информация о рейсах, см. <see cref="FlightInfo"/></returns>
        List<FlightInfo> GetFlightInfos(IEnumerable<int> flightIds);
    }
}
