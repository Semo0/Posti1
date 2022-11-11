using System.Security.Claims;
using HttpClient;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp1.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IauthService authService;

    public CustomAuthProvider(IauthService authService)
    {
        this.authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authService.GetAuthAsync();
        
        return new AuthenticationState(principal);
    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}