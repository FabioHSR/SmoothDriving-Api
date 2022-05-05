using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
namespace SmoothDrivingAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        [NotMapped]
        public List<ObjectId> Vehicles { get; set; }
    }
}
