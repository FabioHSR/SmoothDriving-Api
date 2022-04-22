using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class BaseEntity
    {
        [BsonIgnore]
        public int Id { get; set; }
    }
}
