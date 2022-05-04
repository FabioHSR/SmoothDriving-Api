using SmoothDrivingAPI.Domain.Enums;
namespace SmoothDrivingAPI.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        public string Year { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public string Score { get; set; }
        public string CNH { get; set; }
        public IPVAEnum IPVA { get; set; }
    }
}
