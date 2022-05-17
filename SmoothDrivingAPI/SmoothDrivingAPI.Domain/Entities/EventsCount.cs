using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SmoothDrivingAPI.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class EventsCount
    {
        public EventsCount(){   }

        public EventsCount(
            int CurvasAgressivas,
            int TrocasAgressivas,
            int RPMmedio,
            int VelocidadeMax,
            int VelocidadeMedia ){
            this.CurvasAgressivas = CurvasAgressivas;
            this.TrocasAgressivas = TrocasAgressivas;
            this.RPMmedio = RPMmedio;
            this.VelocidadeMax = VelocidadeMax;
            this.VelocidadeMedia = VelocidadeMedia;
        }
        public int CurvasAgressivas { get; set; }
        public int TrocasAgressivas { get; set; }
        public int RPMmedio { get; set; }
        public int VelocidadeMax { get; set; }
        public int VelocidadeMedia { get; set; }
    }
}
