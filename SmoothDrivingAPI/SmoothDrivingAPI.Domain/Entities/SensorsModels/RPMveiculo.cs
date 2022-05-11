namespace SmoothDrivingAPI.Domain.Entities.SensorsModels
{
    public class RPMveiculo
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata metadata { get; set; }
    }
}