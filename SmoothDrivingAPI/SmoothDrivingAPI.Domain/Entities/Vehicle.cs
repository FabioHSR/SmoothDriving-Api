using SmoothDrivingAPI.Domain.Enums;
namespace SmoothDrivingAPI.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public TransmissionsEnum Transmission { get; set; }
        public string Year { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public double Score { get; set; }
        public string CNH { get; set; }
        public IPVAEnum IPVA { get; set; }
        public int MaxSpeedReached { get; set; }
        public int MaxRPMReached { get; set; }
    }
}
