using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using model.DTOs;
using model.Models;

namespace HttpClient.Implementations;

public class UserHttpClient : IUserService
{
    private readonly System.Net.Http.HttpClient client;

    public UserHttpClient(System.Net.Http.HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> Create(UserCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Users", dto);
        String result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)

        {
            throw new Exception(result);

        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;

    }
}