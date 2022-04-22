using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class SensorData : BaseEntity
    {
        [BsonId]

        public ObjectId ObjectId { get; set; }
        [BsonElement("_userId")]

        public int UserId { get; set; }

        [BsonElement("_equipmentId")]
        public int EquipmentId { get; set; }

        [BsonElement("acelerometer")]
        public AcelerometerData acelerometerData { get; set; }
        [BsonElement("timeStamp")]

        public DateTime timeStamp { get; set; }

    }
}
