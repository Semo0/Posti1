using System.Threading.Tasks;
using model.DTOs;
using model.Models;

namespace HttpClient;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
}