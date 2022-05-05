using System;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public DateTime DateTimeInicio { get; set; }
        public DateTime DateTimeFim { get; set; }
        public TimeSpan Duration { get; set; }
        public EventsCount EventsCount { get; set; }
        public int MaxRPMReached { get; set; }
        public int MaxRPMSpeed { get; set; }
    }
}
