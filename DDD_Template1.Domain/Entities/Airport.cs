namespace DDD_Template1.Domain
{
    public class Airport
    {
        // Variables are not following code specifications because it represents exactly the model from JSON

        public string continent { get; set; }
        public string iata { get; set; }
        public string iso { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public int status { get; set; }
        public string type { get; set; }

        public static class AirportFactory
        {
            public static Airport Create(string continent, string IATA, string ISO, double lat, double lon, string name, string size, int status, string type)
            {
                return new Airport
                {
                    continent = continent,
                    iata = IATA,
                    iso = ISO,
                    lat = lat,
                    lon = lon,
                    name = name,
                    size = size,
                    status = status,
                    type = type
                };
            }
        }
    }
}