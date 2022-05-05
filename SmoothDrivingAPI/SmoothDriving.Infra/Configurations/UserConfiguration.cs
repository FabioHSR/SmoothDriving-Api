using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothDrivingAPI.Domain.Entities;
using MongoDB.Bson;

namespace SmoothDriving.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                    new User
                    {
                        Id = new ObjectId(),
                        Name = "Fábio Rocha",
                        Email = "fhdsr1@gmail.com",
                        Password = "1234"
                    },
                    new User
                    {
                        Id = new ObjectId(),
                        Name = "Guilherme Xavier",
                        Email = "guixavi@gmail.com",
                        Password = "1324"
                    }
                );
        }
    }
}
