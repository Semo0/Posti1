namespace model.DTOs;

public class UserCreationDto
{
    public UserCreationDto(string username, string nickname, string password)
    {
        Username = username;
        Nickname = nickname;
        Password = password;
    }

    public string  Username { get; set; }
    public string Nickname { get; set; }
    public string Password { get; set; }
}