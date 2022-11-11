using model.DTOs;
using model.Models;

namespace HttpClient;

public interface IPostService
{
    Task<Post> createAcync(PostCreationDto dto);
    Task<ICollection<Post>> getAsync();
}