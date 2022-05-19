using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class BrokerTrip
    {
        [BsonElement("_id")]
        public string tripId { get; set; }

        [BsonElement("minTripDate")]
        [DefaultValue("0001-01-01T00:00:00")]
        public DateTime DateTimeStart { get; set; }

        [BsonElement("maxTripDate")]
        [DefaultValue("0001-01-01T00:00:00")]
        public DateTime DateTimeEnd { get; set; }
    }
}