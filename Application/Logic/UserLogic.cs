using System;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using model.DTOs;
using model.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic

{
    private readonly IUserDao USerDao;
    public UserLogic(IUserDao USerDao)
    {
        this.USerDao = USerDao;
    }

    public async Task<User> CreateNewUserAsync(UserCreationDto dto)
    {
        User? existing = await USerDao.GetUserByNameAsync(dto.Username);
        if (existing!=null)
        {
            throw new Exception("UserNamer is already exist please try another one(*_*)");
        }

        VlidateData(dto);
        User tocreate = new User
        {
            username = dto.Username,
            nickname = dto.Nickname,
            password = dto.Password,
            Role = "User"

        };
        User created = await USerDao.CreateAsync(tocreate);
        return created;
    }

    public async Task<User?> GetUserById(string username)
    {
        User? user = await USerDao.GetUserByNameAsync(username);
        return user;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParameterDto parameters)
    {
        return USerDao.GetAsync(parameters);
    }

    private static void VlidateData(UserCreationDto dto)
    {
        string Username = dto.Username;
        string Nickname = dto.Nickname;
        string Password = dto.Password;
        if (Username.Length<3)
        {
            throw new Exception("USer name must be more than 3 characters");

        }

        if (Username.Length>10)
        {
            throw new Exception("username cannot be more than 10 characters");

        }
        if (Nickname.Length<3)
        {
            throw new Exception("Nickname must be more than 3 characters");

        }

        if (Nickname.Length>10)
        {
            throw new Exception("Nickname cannot be more than 10 characters");

        }

        
        
        }
}