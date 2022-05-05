using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SmoothDrivingAPI.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity(){
            Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public ObjectId Id { get; set; }
    }
}
