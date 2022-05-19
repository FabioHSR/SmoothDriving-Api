using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IBrokerTripRepository
    {
        List<BrokerTrip> GetBrokerTrips(string EntityId);
    }
}
