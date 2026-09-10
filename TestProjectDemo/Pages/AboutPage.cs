using Microsoft.Playwright;

namespace TestProjectDemo.Pages;

public sealed class AboutPage : BasePage
{
    public AboutPage(IPage page, string baseUrl) : base(page, baseUrl)
    {
    }

    public ILocator Heading => Page.GetByRole(AriaRole.Heading, new() { Name = "About." });
    public ILocator Message => Page.GetByText("Your application description page.");

    public Task GoAsync() => NavigateAsync("/Home/About");

    public async Task<bool> IsDisplayedAsync()
    {
        return await Heading.IsVisibleAsync() && await Message.IsVisibleAsync();
    }
}
