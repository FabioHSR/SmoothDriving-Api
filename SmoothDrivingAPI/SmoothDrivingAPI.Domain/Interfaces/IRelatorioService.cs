using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IRelatorioService : IBaseService<Relatorio>
    {
        int calculateRelatorioDuration(DateTime start, DateTime end);
        Tuple<List<string>, bool> ValidateDocument(Relatorio relatorio);
    }
}
