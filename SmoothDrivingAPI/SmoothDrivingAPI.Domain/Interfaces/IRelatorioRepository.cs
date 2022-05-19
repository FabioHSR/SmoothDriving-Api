using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IRelatorioRepository : IBaseRepository<Relatorio>
    {
        Relatorio SelectByTripId(string tripId);
    }
}
