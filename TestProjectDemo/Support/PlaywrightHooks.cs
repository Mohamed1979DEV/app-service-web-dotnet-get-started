using Reqnroll;
using Reqnroll.BoDi;
using TestProjectDemo.Pages;

namespace TestProjectDemo.Support;

[Binding]
public sealed class PlaywrightHooks
{
    private readonly IObjectContainer _container;
    private BrowserDriver? _driver;

    public PlaywrightHooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public async Task BeforeScenarioAsync()
    {
        var settings = TestSettings.Load();
        _driver = new BrowserDriver(settings);
        await _driver.StartAsync();

        _container.RegisterInstanceAs(settings);
        _container.RegisterInstanceAs(_driver);
        _container.RegisterInstanceAs(_driver.Page);
        _container.RegisterInstanceAs(new PageFactory(_driver.Page, settings));
    }

    [AfterScenario]
    public async Task AfterScenarioAsync()
    {
        if (_driver is not null)
        {
            await _driver.DisposeAsync();
        }
    }
}
