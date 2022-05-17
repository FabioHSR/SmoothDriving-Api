using System.Collections.Generic;
using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class RelatorioRepository : BaseRepository<Relatorio>, IRelatorioRepository
    { 
        public RelatorioRepository(IMongoClient mongoClient) : base(mongoClient, "Relatorio-Viagem", "smooth-driving-db") {    }
    }
}