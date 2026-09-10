using Reqnroll;
using TestProjectDemo.Pages;

namespace TestProjectDemo.Steps;

[Binding]
public sealed class ContactSteps
{
    private readonly PageFactory _pages;

    public ContactSteps(PageFactory pages)
    {
        _pages = pages;
    }

    [Given("je ouvre la page contact")]
    [When("je ouvre la page contact")]
    public async Task OuvreLaPageContact()
    {
        await _pages.Contact.GoAsync();
    }
}
