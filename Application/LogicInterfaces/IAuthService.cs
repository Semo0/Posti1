using model.Models;

namespace Application.LogicInterfaces;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
}