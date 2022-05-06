using System;
using System.Collections.Generic;
using System.Linq;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class UserService : BaseService<User>, IUserService
  {
    public Tuple<List<string>, bool> ValidateDocument(User user)
    {
      bool validation = true;
      List<string> invalidFields = new List<string>();

      if(!IsValidEmail(user.Email)){
        validation = false;
        invalidFields.Add("Email");
      }

      return Tuple.Create(invalidFields, validation);
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