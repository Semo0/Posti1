using System.Threading.Tasks;
using model.DTOs;
using model.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User?> GetUserByNameAsync(string dtoUsername);
    Task<User> CreateAsync(User user);
    public Task<IEnumerable<User>> GetAsync(SearchUserParameterDto searchParameters);
}