using System.Collections.Generic;

namespace DDD_Template1.Domain.Interfaces.Services
{
    public interface IAirportListService
    {
        IEnumerable<Airport> GetAirportList();
    }
}