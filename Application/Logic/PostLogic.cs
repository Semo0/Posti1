using Application.DaoInterfaces;
using Application.LogicInterfaces;
using model.DTOs;
using model.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao PostDao;
    private readonly IUserDao UserDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        PostDao = postDao;
        UserDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await UserDao.GetUserByNameAsync(dto.Ownername);
        //Console.WriteLine(user.ToString());
        if (user== null)
        {
            throw new Exception($"USer with Id{dto.Ownername} was not found");
        }

        Post post = new Post(dto.Tittle,dto.Content,user);
        
        Post created = await PostDao.CreateAsync(post);
        
        return created;

    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParameterDto searchPostParameterDto)
    {
        return PostDao.GetAsync(searchPostParameterDto);
    }

    public Task<Post> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}