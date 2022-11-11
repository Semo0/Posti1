namespace model.DTOs;

public class PostCreationDto
{
    public string Tittle { get; set; }
    public string Content { get; set; }
    
    public string Ownername { get; set; }

    public PostCreationDto(string tittle, string content,string ownername)
    {
        Tittle = tittle;
        Content = content;
        Ownername = ownername;
    }
}