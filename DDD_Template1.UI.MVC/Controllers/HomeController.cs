using AutoMapper;
using DDD_Template1.Domain.DTOs;
using DDD_Template1.Domain.Interfaces.Notifications;
using DDD_Template1.Domain.Interfaces.Services;
using DDD_Template1.UI.MVC.Enums;
using DDD_Template1.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DDD_Template1.UI.MVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region Private vars

        private readonly IAirportExhibitionService _airportExhibitionService;

        #endregion Private vars

        #region Ctors

        public HomeController(IMapper mapper, IDomainNotificationHandler notification, IAirportExhibitionService airportExhibitionService)
            : base(mapper, notification)
        {
            _airportExhibitionService = airportExhibitionService;
        }

        #endregion Ctors

        #region MVC Actions

        public ActionResult Index()
        {
            return View();
        }

        #endregion MVC Actions

        #region AJAX Actions

        public ActionResult GetEuropeanAirports(AirportFilterDTO filters)
        {
            var europeanAirports = _airportExhibitionService.GetEuropeanAirports(filters);

            var europeanAirportsViewModel = _mapper.Map<List<AirportViewModel>>(europeanAirports);

            return PartialView("_AirportListItem", europeanAirportsViewModel);
        }

        public ActionResult GetDistance(string iata1, string iata2)
        {
            var distanceResult = _airportExhibitionService.GetDistance(iata1, iata2);

            var uri = new Uri(Request.Url.AbsoluteUri);
            var requested = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Host}:{uri.Port}";
            distanceResult.Url = $"{requested}/Home/GetDistance?iata1={iata1}&iata2={iata2}";

            return Json(distanceResult, JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}