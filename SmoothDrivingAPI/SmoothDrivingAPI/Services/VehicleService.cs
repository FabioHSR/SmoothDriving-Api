using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Enums;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class VehicleService : BaseService<Vehicle>, IVehicleService
  {
    private readonly IVehicleRepository _vehicleRepository;
    public VehicleService(IVehicleRepository _vehicleRepository)
    {
      this._vehicleRepository = _vehicleRepository;
    }
    public Tuple<List<string>, bool> ValidateDocument(Vehicle vehicle)
    {
      List<string> invalidFields = new List<string>();

      ValidateYear(vehicle.Year, ref invalidFields);

      ValidateNullFields(vehicle, ref invalidFields);

      return ServiceUtils.ValidateInvalidFields(invalidFields);
    }
    private void ValidateNullFields(Vehicle vehicle, ref List<string> invalidFields)
    {
      string mensagemPrefix = "Informe os campos: ";
      string mensagem = mensagemPrefix;

      if (string.IsNullOrEmpty(vehicle.Plate))
      {
        mensagem += "Placa; ";
      }
      if (string.IsNullOrEmpty(vehicle.Manufacturer))
      {
        mensagem += "Fabricante; ";
      }
      if (string.IsNullOrEmpty(vehicle.Model))
      {
        mensagem += "Modelo; ";
      }
      if (string.IsNullOrEmpty(vehicle.Transmission))
      {
        mensagem += "Transmissão; ";
      }
      if (string.IsNullOrEmpty(vehicle.Fuel))
      {
        mensagem += "Combustível; ";
      }
      if (string.IsNullOrEmpty(vehicle.Color))
      {
        mensagem += "Cor; ";
      }
      if(mensagem != mensagemPrefix)
      {
        invalidFields.Add(mensagem);
      }
    }

    private void ValidateYear(int Year, ref List<string> invalidFields)
    {
      if(Year > DateTime.Now.Year){
        invalidFields.Add("Year must be less than current year.");
      }
    }
  }
}