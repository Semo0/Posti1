using model.DTOs;
using model.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto todo);
    Task<IEnumerable<Post>> GetAsync(SearchPostParameterDto searchTodoParameterDto);
    //  Task UpdateAsync(Post dto);
    Task<Post> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}