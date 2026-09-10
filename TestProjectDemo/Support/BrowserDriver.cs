using Microsoft.Playwright;

namespace TestProjectDemo.Support;

public sealed class BrowserDriver : IAsyncDisposable
{
    public IPlaywright Playwright { get; private set; } = null!;
    public IBrowser Browser { get; private set; } = null!;
    public IBrowserContext Context { get; private set; } = null!;
    public IPage Page { get; private set; } = null!;
    public TestSettings Settings { get; }

    public BrowserDriver(TestSettings settings)
    {
        Settings = settings;
    }

    public async Task StartAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = Settings.Playwright.Headless,
            SlowMo = Settings.Playwright.SlowMo
        });

        Context = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = true,
            BaseURL = Settings.BaseUrl.TrimEnd('/')
        });

        Page = await Context.NewPageAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (Context is not null)
        {
            await Context.CloseAsync();
        }

        if (Browser is not null)
        {
            await Browser.CloseAsync();
        }

        Playwright?.Dispose();
    }
}
