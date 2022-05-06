using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Tuple<List<string>, bool> ValidateDocument(User user);

        string CreateHashPassword(string password);

        bool IsValidPassword(string password, string hashPassword);
    }
}
