using Microsoft.Playwright;

namespace TestProjectDemo.Pages;

public sealed class LoginPage : BasePage
{
    public LoginPage(IPage page, string baseUrl) : base(page, baseUrl)
    {
    }

    public ILocator UsernameInput => Page.Locator("#Username");
    public ILocator PasswordInput => Page.Locator("#Password");
    public ILocator SubmitButton => Page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
    public ILocator Heading => Page.GetByRole(AriaRole.Heading, new() { Name = "Login" });
    public ILocator ValidationSummary => Page.Locator(".validation-summary-errors, .text-danger").First;

    public Task GoAsync() => NavigateAsync("/Account/Login");

    public async Task LoginAsync(string username, string password)
    {
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);
        await SubmitButton.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<bool> IsDisplayedAsync()
    {
        return await Heading.IsVisibleAsync()
               && Page.Url.Contains("/Account/Login", StringComparison.OrdinalIgnoreCase);
    }
}
