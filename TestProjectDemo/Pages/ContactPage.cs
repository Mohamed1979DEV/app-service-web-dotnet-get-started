using Microsoft.Playwright;

namespace TestProjectDemo.Pages;

public sealed class ContactPage : BasePage
{
    public ContactPage(IPage page, string baseUrl) : base(page, baseUrl)
    {
    }

    public ILocator Heading => Page.GetByRole(AriaRole.Heading, new() { Name = "Contact." });
    public ILocator Address => Page.GetByText("One Microsoft Way");
    public ILocator SupportEmail => Page.GetByRole(AriaRole.Link, new() { Name = "Support@example.com" });

    public Task GoAsync() => NavigateAsync("/Home/Contact");

    public async Task<bool> IsDisplayedAsync()
    {
        return await Heading.IsVisibleAsync()
               && await Address.IsVisibleAsync()
               && await SupportEmail.IsVisibleAsync();
    }
}
