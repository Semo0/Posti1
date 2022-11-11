namespace model.Models;

public class Post
{
    public int Id { get; set; }
    public String Tittel { get; set; }
    public String Content { get; set; }
    public User Owner { get; set; }

    public Post(string tittel, string content, User owner)
    {
        Tittel = tittel;
        Content = content;
        Owner = owner;
    }
}