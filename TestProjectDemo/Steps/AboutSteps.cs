using Reqnroll;
using TestProjectDemo.Pages;

namespace TestProjectDemo.Steps;

[Binding]
public sealed class AboutSteps
{
    private readonly PageFactory _pages;

    public AboutSteps(PageFactory pages)
    {
        _pages = pages;
    }

    [Given("je ouvre la page apropos")]
    [When("je ouvre la page apropos")]
    public async Task OuvreLaPageAPropos()
    {
        await _pages.About.GoAsync();
    }
}
