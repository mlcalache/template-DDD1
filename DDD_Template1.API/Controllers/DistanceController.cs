using AutoMapper;
using DDD_Template1.Domain.Interfaces.Notifications;
using DDD_Template1.Domain.Interfaces.Services;
using System.Web.Http;

namespace DDD_Template1.API.Controllers
{
    [Authorize]
    public class DistanceController : BaseApiController
    {
        #region Private vars

        private readonly IAirportExhibitionService _airportExhibitionService;

        #endregion Private vars

        #region Ctors

        public DistanceController(IMapper mapper, IDomainNotificationHandler notification, IAirportExhibitionService airportExhibitionService)
            : base(mapper, notification)
        {
            _airportExhibitionService = airportExhibitionService;
        }

        #endregion Ctors

        public IHttpActionResult Get(string iata1, string iata2)
        {
            if (string.IsNullOrEmpty(iata1) && string.IsNullOrEmpty(iata2))
            {
                return BadRequest();
            }

            var airport1 = _airportExhibitionService.GetAirport(iata1);

            if (airport1 == null)
            {
                return NotFound();
            }

            var airport2 = _airportExhibitionService.GetAirport(iata2);

            if (airport2 == null)
            {
                return NotFound();
            }

            var distance = _airportExhibitionService.GetDistance(airport1, airport2);

            if (distance == null)
            {
                return InternalServerError();
            }

            return Ok(distance);
        }
    }
}