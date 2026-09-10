using Microsoft.Playwright;
using TestProjectDemo.Support;

namespace TestProjectDemo.Pages;

public sealed class PageFactory
{
    private readonly IPage _page;
    private readonly TestSettings _settings;

    public PageFactory(IPage page, TestSettings settings)
    {
        _page = page;
        _settings = settings;
    }

    public LoginPage Login => new(_page, _settings.BaseUrl);
    public HomePage Home => new(_page, _settings.BaseUrl);
    public AboutPage About => new(_page, _settings.BaseUrl);
    public ContactPage Contact => new(_page, _settings.BaseUrl);
}
