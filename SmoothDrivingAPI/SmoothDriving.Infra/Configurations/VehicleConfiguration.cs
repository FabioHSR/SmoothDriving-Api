using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Enums;
namespace SmoothDriving.Infra.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(
                    new 
                    {
                        Id = 1,
                        Plate = "ABC-1231",
                        Manufacturer = "Volkswagen",
                        Model = "Fusca",
                        Transmission = "Manual",
                        Year = "2020",
                        Fuel = "Gasolina",
                        Color = "Preto",
                        IPVA = IPVAEnum.Pago,
                        Score = "10",
                        CNH = ""
                    }
                );
        }
    }
}
