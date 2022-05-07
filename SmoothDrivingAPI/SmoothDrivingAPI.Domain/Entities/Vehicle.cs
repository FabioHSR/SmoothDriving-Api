using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmoothDrivingAPI.Domain.Enums;

namespace SmoothDrivingAPI.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        
        [Range(1960, 9999, ErrorMessage = "Valor não pode ser menor que 1960")]
        public int Year { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public double Score { get; set; }
        public string CNH { get; set; }
        public string IPVA { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Valor não pode ser negativo")]
        public int MaxSpeedReached { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Valor não pode ser negativo")]
        public int MaxRPMReached { get; set; }
    }
}
