using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class RelatorioService : BaseService<Relatorio>, IRelatorioService
  {
    private readonly IUserRepository _userRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public RelatorioService(IUserRepository _userRepository, IVehicleRepository _vehicleRepository)
    {
      this._userRepository = _userRepository;
      this._vehicleRepository = _vehicleRepository;
    }
    public Tuple<List<string>, bool> ValidateDocument(Relatorio relatorio){
      List<string> invalidFields = new List<string>();

      ValidateEndDate(relatorio.DateTimeStart, relatorio.DateTimeEnd, ref invalidFields);

      return ServiceUtils.ValidateInvalidFields(invalidFields);
    }
    public int calculateRelatorioDuration(DateTime start, DateTime end){
      return (int)(end - start).TotalMilliseconds;
    }
    private void ValidateEndDate(
      DateTime DateTimeStart, 
      DateTime DateTimeEnd, 
      ref List<string> invalidFields){

      if(DateTimeStart > DateTimeEnd){
        invalidFields.Add("DateTimeEnd must be greater than DateTimeStart.");
      }
    }
  }
}