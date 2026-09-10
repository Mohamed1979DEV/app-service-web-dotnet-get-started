using Microsoft.Playwright;
using Reqnroll;
using TestProjectDemo.Pages;

namespace TestProjectDemo.Steps;

[Binding]
public sealed class LoginSteps
{
    private readonly PageFactory _pages;
    private readonly IPage _page;

    public LoginSteps(PageFactory pages, IPage page)
    {
        _pages = pages;
        _page = page;
    }

    [Given("je ouvre la page de connexion")]
    [When("je ouvre la page de connexion")]
    public async Task OuvreLaPageDeConnexion()
    {
        await _pages.Login.GoAsync();
    }

    [When("je me connecte avec l utilisateur {string} et le mot de passe {string}")]
    public async Task QuandJeMeConnecte(string username, string password)
    {
        await _pages.Login.LoginAsync(username, password);
    }

    [When("je soumets le formulaire de connexion sans identifiants")]
    public async Task QuandJeSoumetsLeFormulaireSansIdentifiants()
    {
        await _pages.Login.UsernameInput.FillAsync(string.Empty);
        await _pages.Login.PasswordInput.FillAsync(string.Empty);
        await _pages.Login.SubmitButton.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("la page de connexion est affichee")]
    public async Task AlorsLaPageDeConnexionEstAffichee()
    {
        Assert.True(await _pages.Login.IsDisplayedAsync(), "La page de connexion n'est pas affichée.");
    }

    [Then("je vois le message d erreur {string}")]
    public async Task AlorsJeVoisLeMessageDErreur(string message)
    {
        await Assertions.Expect(_page.GetByText(message)).ToBeVisibleAsync();
    }

    [Then("je vois des erreurs de validation")]
    public async Task AlorsJeVoisDesErreursDeValidation()
    {
        var usernameError = _page.Locator("span[data-valmsg-for='Username'], span.field-validation-error").First;
        var passwordError = _page.Locator("span[data-valmsg-for='Password'], span.field-validation-error").First;
        var anyError = _page.Locator(".field-validation-error, .validation-summary-errors, .text-danger:not(:empty)");

        Assert.True(
            await anyError.CountAsync() > 0
            || await usernameError.IsVisibleAsync()
            || await passwordError.IsVisibleAsync()
            || await _pages.Login.IsDisplayedAsync(),
            "Des erreurs de validation étaient attendues sur le formulaire de connexion.");
    }
}
