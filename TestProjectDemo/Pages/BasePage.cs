using Microsoft.Playwright;

namespace TestProjectDemo.Pages;

public abstract class BasePage
{
    protected readonly IPage Page;
    protected readonly string BaseUrl;

    protected BasePage(IPage page, string baseUrl)
    {
        Page = page;
        BaseUrl = baseUrl.TrimEnd('/');
    }

    public async Task NavigateAsync(string relativePath = "/")
    {
        var path = relativePath.StartsWith('/') ? relativePath : "/" + relativePath;
        await Page.GotoAsync(BaseUrl + path, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
    }

    public Task<string> GetTitleAsync() => Page.TitleAsync();

    public ILocator NavLink(string text) => Page.Locator($"nav a, .navbar a:has-text(\"{text}\")").First;

    public async Task ClickNavLinkAsync(string text)
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = text }).First.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        return await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).IsVisibleAsync();
    }

    public async Task<string> GetGreetingTextAsync()
    {
        return (await Page.Locator(".navbar-right a").First.InnerTextAsync()).Trim();
    }
}
