namespace model.DTOs;

public class SearchPostParameterDto
{
    public string? Username { get; set; }
    public int? UserId { get; set; }
    public string? Posttittle { get; set; }

    public SearchPostParameterDto(string? username, int? userId, string? posttittle)
    {
        Username = username;
        UserId = userId;
        Posttittle = posttittle;
    }
}