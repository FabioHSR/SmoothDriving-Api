using SmoothDrivingAPI.Domain.Entities.SensorsModels;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Sensores: BaseEntity
    {
        public string id { get; set; }
        public string type { get; set; }
        public EixoXAcelerometro EixoXAcelerometro { get; set; }
        public EixoXGiroscopio EixoXGiroscopio { get; set; }
        public EixoYAcelerometro EixoYAcelerometro { get; set; }
        public EixoYGiroscopio EixoYGiroscopio { get; set; }
        public EixoZAcelerometro EixoZAcelerometro { get; set; }
        public EixoZGiroscopio EixoZGiroscopio { get; set; }
        public IdViagem IdViagem { get; set; }
        public RPMveiculo RPMveiculo { get; set; }
        public Velocidade Velocidade { get; set; }
    }
}