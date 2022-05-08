using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SmoothDrivingAPI.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity(){
            if(Id == null){
                Id = ObjectId.GenerateNewId().ToString();
            }
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }
    }
}
