using SmoothDrivingAPI.Domain.Entities.SensorsModels;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Sensores: BaseEntity
    {
        public string id { get; set; }
        public string type { get; set; }
        public AceleracaoVeiculo AceleracaoVeiculo { get; set; }
        public DistanciaCodLimpo DistanciaCodLimpo { get; set; }
        public EixoXAcelerometro EixoXAcelerometro { get; set; }
        public EixoXGiroscopio EixoXGiroscopio { get; set; }
        public EixoYAcelerometro EixoYAcelerometro { get; set; }
        public EixoYGiroscopio EixoYGiroscopio { get; set; }
        public EixoZAcelerometro EixoZAcelerometro { get; set; }
        public EixoZGiroscopio EixoZGiroscopio { get; set; }
        public IdViagem IdViagem { get; set; }
        public NivelCombustivel NivelCombustivel { get; set; }
        public PorcentagemEtanol PorcentagemEtanol { get; set; }
        public RPMveiculo RPMveiculo { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public VelocidadeVeiculo VelocidadeVeiculo { get; set; }
    }
}