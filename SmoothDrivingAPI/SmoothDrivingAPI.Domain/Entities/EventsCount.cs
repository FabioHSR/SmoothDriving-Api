using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SmoothDrivingAPI.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class EventsCount
    {
        public EventsCount(
            int CurvaEsquerda, 
            int CurvaDireita,
            int TrocaFaixaEsquerda, 
            int TrocaFaixaDireita, 
            int AceleracaoBrusca, 
            int FrenagemBrusca)
        {
            this.CurvaEsquerda = CurvaEsquerda;
            this.CurvaDireita = CurvaDireita;
            this.TrocaFaixaEsquerda = TrocaFaixaEsquerda;
            this.TrocaFaixaDireita = TrocaFaixaDireita;
            this.AceleracaoBrusca = AceleracaoBrusca;
            this.FrenagemBrusca = FrenagemBrusca;
        }
        [BsonId]
        [BsonIgnore]
        public ObjectId Id { get; set; }
        public int CurvaEsquerda {get; set;}
        public int CurvaDireita {get; set;}
        public int TrocaFaixaEsquerda {get; set;}
        public int TrocaFaixaDireita {get; set;}
        public int AceleracaoBrusca {get; set;}
        public int FrenagemBrusca {get; set;}
    }
}
