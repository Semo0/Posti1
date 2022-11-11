using System.Threading.Tasks;
using model.DTOs;
using model.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateNewUserAsync(UserCreationDto usertocreate);
    Task<User?> GetUserById(string username);
    Task<IEnumerable<User>> GetAsync(SearchUserParameterDto parameters);
}