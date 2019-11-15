using DDD_Template1.Domain.Enums;

namespace DDD_Template1.Domain.DTOs
{
    public class AirportFilterDTO
    {
        public string IATA { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public SizeEnum? Size { get; set; }
        public TypeEnum? Type { get; set; }
    }
}