using Application.DaoInterfaces;
using Application.LogicInterfaces;
using model.Models;

namespace Application.Logic;

public class AuthService : IAuthService
{
    private readonly IAuthDao _dao;

    public AuthService(IAuthDao dao)
    {
        _dao = dao;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await _dao.ValidateUserAsync(username, password);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }


}