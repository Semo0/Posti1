
using System.Text.Json;
using model.Models;

namespace FileData;

public class FileContext
{
    private const string FilePath = "data1.json";
    private DataContainer? DataContainer;


    public ICollection<Post> Posts
    {
        get
        {
            LazyLoadData();
            return DataContainer!.Posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LazyLoadData();
            return DataContainer!.Users;
        }
    }

    private void  LazyLoadData()
    {
        if (DataContainer==null)
        {
           LoadData();
        } 
    }

    private void LoadData()
    {
        if (DataContainer!=null)return;
        if (!File.Exists(FilePath))
        {
            DataContainer = new ()
            {
                Users = new List<User>(),
                Posts = new List<Post>()
            };
           return;

        }

        string content = File.ReadAllText(FilePath);
        DataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(DataContainer,new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(FilePath,serialized);
        DataContainer = null;
    }
}