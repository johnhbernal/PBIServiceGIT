using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PBIServices.Tests;

/// <summary>
/// The lab's lesson, pinned: /health is anonymous, data APIs answer 401 without a JWT,
/// the seeded demo user gets a token at /api/Token and that token opens /api/Lineas.
/// WebApplicationFactory boots the real Startup (InMemory + simulated directory), so
/// nothing here can reach a corporate database or a real LDAP bind.
/// </summary>
public class AuthFlowTests : IClassFixture<WebApplicationFactory<InventoryService.Program>>
{
    private readonly WebApplicationFactory<InventoryService.Program> _factory;

    public AuthFlowTests(WebApplicationFactory<InventoryService.Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Health_is_anonymous()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Lineas_without_token_answers_401()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/Lineas");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Token_with_bad_password_answers_401()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/Token",
            new { email = "admin@demo.local", password = "wrong-password" });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Token_without_credentials_answers_400()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/Token", new { email = "", password = "" });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Demo_admin_token_opens_Lineas()
    {
        var client = _factory.CreateClient();

        var login = await client.PostAsJsonAsync("/api/Token",
            new { email = "admin@demo.local", password = "Admin123!" });
        Assert.Equal(HttpStatusCode.OK, login.StatusCode);

        using var payload = JsonDocument.Parse(await login.Content.ReadAsStringAsync());
        var token = payload.RootElement.GetProperty("token").GetString();
        Assert.False(string.IsNullOrWhiteSpace(token));

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var lines = await client.GetAsync("/api/Lineas");

        Assert.Equal(HttpStatusCode.OK, lines.StatusCode);
        Assert.Contains("L01", await lines.Content.ReadAsStringAsync());
    }
}
