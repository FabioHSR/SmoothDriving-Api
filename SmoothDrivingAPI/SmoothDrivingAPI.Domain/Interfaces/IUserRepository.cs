using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool EmailExists(string Email);

        User SelectByEmail(string Email);
    }
}
