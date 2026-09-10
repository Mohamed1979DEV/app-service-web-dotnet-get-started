using System.Text.Json;

namespace TestProjectDemo.Support;

public sealed class TestSettings
{
    public string BaseUrl { get; init; } = "https://localhost:44320";
    public AuthSettings Auth { get; init; } = new();
    public PlaywrightSettings Playwright { get; init; } = new();

    public static TestSettings Load()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        if (!File.Exists(path))
        {
            return new TestSettings();
        }

        var json = File.ReadAllText(path);
        var settings = JsonSerializer.Deserialize<TestSettings>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        var fromEnv = Environment.GetEnvironmentVariable("BASE_URL");
        if (!string.IsNullOrWhiteSpace(fromEnv) && settings is not null)
        {
            return new TestSettings
            {
                BaseUrl = fromEnv.TrimEnd('/'),
                Auth = settings.Auth,
                Playwright = settings.Playwright
            };
        }

        return settings ?? new TestSettings();
    }
}

public sealed class AuthSettings
{
    public string Username { get; init; } = "admin";
    public string Password { get; init; } = "admin";
}

public sealed class PlaywrightSettings
{
    public bool Headless { get; init; } = true;
    public int SlowMo { get; init; }
}
