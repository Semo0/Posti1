using Application.DaoInterfaces;
using model.Models;

namespace FileData.Daos;

public class AuthDao : IAuthDao
{

    private readonly FileContext _context;

    public AuthDao(FileContext context)
    {
        _context = context;
    }

    public Task<User?> ValidateUserAsync(string username, string password)
    {
        User exist =
            _context.Users.FirstOrDefault(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase))!;
        return Task.FromResult(exist);
    }
}