using AutoMapper;
using Mirabeau.Domain;
using Mirabeau.Domain.DTOs;
using Mirabeau.Domain.Interfaces.Notifications;
using Mirabeau.Domain.Interfaces.Services;
using Mirabeau.Infra.CrossCutting.Helpers;
using Mirabeau.UI.MVC.Enums;
using Mirabeau.UI.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Mirabeau.UI.MVC.Controllers
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
            IEnumerable<Airport> europeanAirports;
            List<AirportViewModel> europeanAirportsViewModel;
            string res;
            var url = ConfigurationManagerHelper.ApiBaseUrl;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", Token);
                var response = client.GetAsync($"{url}/Airport").Result;
                res = string.Empty;
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();
                    res = result.Result;
                }
            }

            if (!string.IsNullOrEmpty(res))
            {
                europeanAirports = JsonConvert.DeserializeObject<List<Airport>>(res);

                europeanAirportsViewModel = _mapper.Map<List<AirportViewModel>>(europeanAirports);

                return PartialView("_AirportListItem", europeanAirportsViewModel);
            }

            europeanAirports = _airportExhibitionService.GetEuropeanAirports(filters);

            europeanAirportsViewModel = _mapper.Map<List<AirportViewModel>>(europeanAirports);

            return PartialView("_AirportListItem", europeanAirportsViewModel);
        }

        public ActionResult GetDistance(string iata1, string iata2)
        {
            double distance;
            var url = ConfigurationManagerHelper.ApiBaseUrl;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", Token);
                var response = client.GetAsync($"{url}/Distance?iata1={iata1}&iata2={iata2}").Result;
                distance = 0;
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();
                    distance = double.Parse(result.Result, System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            var distanceResult = new DistanceResultDTO
            {
                Distance = distance
            };

            var uri = new Uri(Request.Url.AbsoluteUri);
            var requested = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Host}:{uri.Port}";
            distanceResult.Url = $"{requested}/Home/GetDistance?iata1={iata1}&iata2={iata2}";

            if (HasDomainNotifications(AddErrorsOnEnum.ToastMessage))
            {
                foreach (var n in _notification.GetNotifications())
                {
                    distanceResult.Notifications.Add(n.Value);
                }
            }

            return Json(distanceResult, JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}