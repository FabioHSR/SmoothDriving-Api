using System;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Trip : BaseEntity
    {
        [NotMapped]
        public ObjectId CarId { get; set; }
        public string DateTimeStart { get; set; }
        public string DateTimeEnd { get; set; }
        public string Duration { get; set; }
        public EventsCount EventsCount { get; set; }
        public int MaxRPMReached { get; set; }
        public int MaxSpeedReached { get; set; }
        public ObjectId User { get; set; }
    }
}
