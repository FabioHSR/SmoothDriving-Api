using System;

namespace SmoothDrivingAPI.Models
{
    public class RelatorioBodyRequest
    {
        RelatorioBodyRequest()
        {
        }

        RelatorioBodyRequest(String entityId, String tripId)
        {
            this.entity_id = entityId;
            this.trip_id = tripId;
        }
        public String entity_id { get; set; }
        public String trip_id { get; set; }
    }
}