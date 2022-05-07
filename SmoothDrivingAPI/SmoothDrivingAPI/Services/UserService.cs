using System;
using System.Collections.Generic;
using System.Linq;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class UserService : BaseService<User>, IUserService
  {
    private readonly IVehicleRepository _vehicleRepository;
    public UserService(IVehicleRepository _vehicleRepository)
    {
      this._vehicleRepository = _vehicleRepository;
    }

    public Tuple<List<string>, bool> ValidateDocument(User user)
    {
      List<string> invalidFields = new List<string>();

      ValidateEmail(user.Email, ref invalidFields);

      ValidateIfChildDocumentsExist(ref invalidFields, user.Vehicles);

      return ServiceUtils.ValidateInvalidFields(invalidFields);
    }

    private void ValidateIfChildDocumentsExist(
      ref List<string> invalidFields, 
      List<string> vehicleIds){

      foreach(string vehicleId in vehicleIds){
        if(!_vehicleRepository.Exists(vehicleId)){
          invalidFields.Add($"VehicleId {vehicleId} does not exist.");
        }
      }
    }

    private void ValidateEmail(string Email, ref List<string> invalidFields)
    {
      if(!IsValidEmail(Email)){
        invalidFields.Add("Email with invalid format.");
      }
    }

    public bool IsValidEmail(string email)
    {
      var trimmedEmail = email.Trim();
      
      List<char> mustHaveChars = new List<char> { '@', '.' };

      if (mustHaveChars.Any(c => (
        trimmedEmail.EndsWith(c) || !trimmedEmail.Contains(c)
      ))){
        return false;
      }
      try {
          var addr = new System.Net.Mail.MailAddress(email);
          return addr.Address == trimmedEmail;
      }
      catch {
          return false;
      }
    }

    public string CreateHashPassword(string password)
    {
      Console.WriteLine("Creating hash password...");
      return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool IsValidPassword(string password, string hashPassword)
    {
      return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
  }
}