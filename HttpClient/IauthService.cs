using System.Security.Claims;

namespace HttpClient;

public interface IauthService
{
    Task LoginAsync(string username, string password);
    Task LogoutAsync();

    Task<ClaimsPrincipal> GetAuthAsync();

    Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}