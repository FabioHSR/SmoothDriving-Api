using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDriving.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                    new User
                    {
                        Id = 1,
                        Name = "Fábio Rocha",
                        Email = "fhdsr1@gmail.com",
                        Password = "1234"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Guilherme Xavier",
                        Email = "guixavi@gmail.com",
                        Password = "1324"
                    }
                );
        }
    }
}
