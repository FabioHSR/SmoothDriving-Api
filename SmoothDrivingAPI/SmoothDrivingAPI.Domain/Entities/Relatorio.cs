using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Relatorio : BaseEntity
    {
        public string EntityId { get; set; }
        public string TripId { get; set; }

        [DefaultValue("0001-01-01T00:00:00")]
        public DateTime DateTimeEnd { get; set; }

        [DefaultValue("0001-01-01T00:00:00")]
        public DateTime DateTimeStart { get; set; }
        public EventsCount EventsCount { get; set; }
    }
}