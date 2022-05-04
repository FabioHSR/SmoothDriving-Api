namespace SmoothDrivingAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        // public List<Vehicle> Vehicles { get; set; }
    }
}
