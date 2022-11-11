using model.DTOs;
using model.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post todo);
    Task<IEnumerable<Post>> GetAsync(SearchPostParameterDto searchPostParameterDto);
    //  Task UpdateAsync(Post dto);
    Task<Post> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}