using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using model.DTOs;
using model.Models;

namespace FileData.Daos;

public class UserDao : IUserDao
{
    private readonly FileContext context;

    public UserDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User?> GetUserByNameAsync(string Username)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.username.Equals(Username, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<User?>(existing);
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;

        }

        user.Id = userId;
        context.Users.Add(user);
        context.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParameterDto searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u =>
                u.username.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));

        }

        return Task.FromResult(users);
    }
}