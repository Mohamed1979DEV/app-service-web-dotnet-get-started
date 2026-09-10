using Reqnroll;
using TestProjectDemo.Pages;

namespace TestProjectDemo.Steps;

[Binding]
public sealed class HomeSteps
{
    private readonly PageFactory _pages;

    public HomeSteps(PageFactory pages)
    {
        _pages = pages;
    }

    [Given("je ouvre la page accueil")]
    [When("je ouvre la page accueil")]
    public async Task OuvreLaPageDAccueil()
    {
        await _pages.Home.GoAsync();
    }
}
