using System.ComponentModel;

namespace DDD_Template1.UI.MVC.Models
{
    public class AirportViewModel
    {
        [DisplayName("Continent")]
        public string Continent { get; set; }

        [DisplayName("IATA")]
        public string IATA { get; set; }

        [DisplayName("ISO")]
        public string ISO { get; set; }

        [DisplayName("Latitude")]
        public double Latitude { get; set; }

        [DisplayName("Longitude")]
        public double Longitude { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Size")]
        public string Size { get; set; }

        [DisplayName("Status")]
        public int Status { get; set; }

        [DisplayName("Type")]
        public string Type { get; set; }
    }
}