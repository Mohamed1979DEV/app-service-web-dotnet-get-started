using Microsoft.Playwright;

namespace TestProjectDemo.Pages;

public sealed class HomePage : BasePage
{
    public HomePage(IPage page, string baseUrl) : base(page, baseUrl)
    {
    }

    public ILocator HeroHeading => Page.GetByRole(AriaRole.Heading, new() { Name = "ASP.NET" });
    public ILocator GettingStarted => Page.GetByRole(AriaRole.Heading, new() { Name = "Getting started" });

    public Task GoAsync() => NavigateAsync("/");

    public async Task<bool> IsDisplayedAsync()
    {
        return await HeroHeading.IsVisibleAsync();
    }
}
