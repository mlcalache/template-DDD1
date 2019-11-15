using DDD_Template1.Domain;
using DDD_Template1.Domain.Interfaces.Services;
using DDD_Template1.Infra.CrossCutting.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace DDD_Template1.Infra.Service.AirportList
{
    public class AirportListService : IAirportListService
    {
        public IEnumerable<Airport> GetAirportList()
        {
            List<Airport> airports;
            string res;            

            var url = ConfigurationManagerHelper.UrlJsonAirport;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).Result;
                res = string.Empty;
                using (HttpContent content = response.Content)
                {
                    var result = content.ReadAsStringAsync();
                    res = result.Result;
                }
            }

            if (!string.IsNullOrEmpty(res))
            {
                airports = JsonConvert.DeserializeObject<List<Airport>>(res);

                return airports;
            }

            return new List<Airport>();
        }
    }
}