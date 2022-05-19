using System.Collections.Generic;
using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class RelatorioRepository : BaseRepository<Relatorio>, IRelatorioRepository
    {
        public RelatorioRepository(IMongoClient mongoClient) : base(mongoClient, "Relatorio-Viagem", "smooth-driving-db") {    }

        public Relatorio SelectByTripId(string tripId)
        {
            return base.FindByField("TripId", tripId).FirstOrDefault();
        }
    }
}