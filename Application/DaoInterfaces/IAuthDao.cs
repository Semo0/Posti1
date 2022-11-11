using model.Models;

namespace Application.DaoInterfaces;

public interface IAuthDao
{
    Task<User?> ValidateUserAsync(string username, string password);
}