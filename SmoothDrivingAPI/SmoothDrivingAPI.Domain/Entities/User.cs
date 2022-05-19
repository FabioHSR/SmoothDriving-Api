using System.Collections.Generic;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<string> Vehicles { get; set; } = new();
    }
}
