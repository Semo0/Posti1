using Application.DaoInterfaces;
using model.DTOs;
using model.Models;

namespace FileData.Daos;

public class PostDao : IPostDao
{
    private readonly FileContext content;

    public PostDao(FileContext contect)
    {
        this.content = contect;
    }
    

    public Task<Post> CreateAsync(Post post)
    {
        
        int id = 1;
         if (content.Posts.Any())
        {
            id = content.Posts.Max(t => t.Id);
           id++;
        }

        post.Id = id;



        content.Posts.Add(post);
        content.SaveChanges();
        return Task.FromResult(post);

    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParameterDto searchPostParameterDto)
    {
        IEnumerable<Post>? result = content.Posts.AsEnumerable();
        if (!string.IsNullOrEmpty(searchPostParameterDto.Username))
        {
            result = content.Posts.Where(post => post.Owner.username.Equals(searchPostParameterDto.Username));

        }

        if (!string.IsNullOrEmpty(searchPostParameterDto.Posttittle))
        {
            result = content.Posts.Where(p => p.Tittel.Contains(searchPostParameterDto.Posttittle));
            
        }
        return Task.FromResult(result);
    }

    public Task<Post> GetByIdAsync(int id)
    {
        Post? post = content.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(post);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}