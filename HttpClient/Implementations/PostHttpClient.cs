using System.Net.Http.Json;
using System.Text.Json;
using model.DTOs;
using model.Models;

namespace HttpClient.Implementations;

public class PostHttpClient : IPostService
{
    private readonly System.Net.Http.HttpClient client;

    public PostHttpClient(System.Net.Http.HttpClient client)
    {
        this.client = client;
    }

    public async Task<Post> createAcync(PostCreationDto dto)
    {
        
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/Posts",dto);
            String result = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)

            {
                throw new Exception(result);
            }

            Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return post;


        
        
    }

    public async Task<ICollection<Post>> getAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/Posts");
        string all = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(all);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(all, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}