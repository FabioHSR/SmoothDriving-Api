using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public string VehicleId { get; set; }

        [DefaultValue("0001-01-01T00:00:00")]
        public DateTime DateTimeStart { get; set; }

        [DefaultValue("0001-01-01T00:00:00")]
        public DateTime DateTimeEnd { get; set; }

        [JsonIgnore]
        public int Duration { get; set; }
        public EventsCount EventsCountOld { get; set; } = new();
        public int MaxRPMReached { get; set; }
        public int MaxSpeedReached { get; set; }
        public string UserId { get; set; }
    }
}
