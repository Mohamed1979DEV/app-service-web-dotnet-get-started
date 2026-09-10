using Microsoft.Playwright;
using Reqnroll;
using TestProjectDemo.Pages;
using TestProjectDemo.Support;

namespace TestProjectDemo.Steps;

[Binding]
public sealed class CommonSteps
{
    private readonly IPage _page;
    private readonly PageFactory _pages;
    private readonly TestSettings _settings;
    private readonly BrowserDriver _driver;

    public CommonSteps(IPage page, PageFactory pages, TestSettings settings, BrowserDriver driver)
    {
        _page = page;
        _pages = pages;
        _settings = settings;
        _driver = driver;
    }

    // "Etant donné que" / "Étant donné que" inclut déjà "que" dans le mot-clé Gherkin FR
    [Given("je suis authentifie en tant que {string} avec le mot de passe {string}")]
    public async Task EtantDonneQueJeSuisAuthentifie(string username, string password)
    {
        await _pages.Login.GoAsync();
        await _pages.Login.LoginAsync(username, password);
        Assert.True(await _pages.Home.IsDisplayedAsync() || await _pages.Login.IsAuthenticatedAsync(),
            "L'authentification a échoué ; page d'accueil ou lien Logout introuvable.");
    }

    [Given("je ne suis pas authentifie")]
    public async Task EtantDonneQueJeNeSuisPasAuthentifie()
    {
        await _driver.Context.ClearCookiesAsync();
        await _page.GotoAsync(_settings.BaseUrl.TrimEnd('/') + "/Account/Login", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
    }

    [When("je clique sur le lien {string}")]
    public async Task QuandJeCliqueSurLeLien(string linkText)
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = linkText }).First.ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Then("le titre de la page contient {string}")]
    public async Task AlorsLeTitreDeLaPageContient(string expected)
    {
        var title = await _page.TitleAsync();
        Assert.Contains(expected, title, StringComparison.OrdinalIgnoreCase);
    }

    [Then("je vois le titre {string}")]
    public async Task AlorsJeVoisLeTitre(string heading)
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = heading })).ToBeVisibleAsync();
    }

    [Then("je vois le texte {string}")]
    public async Task AlorsJeVoisLeTexte(string text)
    {
        await Assertions.Expect(_page.GetByText(text)).ToBeVisibleAsync();
    }

    [Then("je vois le lien {string}")]
    public async Task AlorsJeVoisLeLien(string linkText)
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Link, new() { Name = linkText })).ToBeVisibleAsync();
    }

    [Then("je vois le message de bienvenue {string}")]
    public async Task AlorsJeVoisLeMessageDeBienvenue(string greeting)
    {
        await Assertions.Expect(_page.GetByText(greeting)).ToBeVisibleAsync();
    }

    [Then("je suis sur la page {word}")]
    public async Task AlorsJeSuisSurLaPage(string pageName)
    {
        switch (pageName.ToLowerInvariant())
        {
            case "accueil":
            case "home":
                Assert.True(await _pages.Home.IsDisplayedAsync(), "Contenu de la page d'accueil attendu.");
                break;
            case "apropos":
            case "about":
                Assert.True(await _pages.About.IsDisplayedAsync(), "Contenu de la page À propos attendu.");
                break;
            case "contact":
                Assert.True(await _pages.Contact.IsDisplayedAsync(), "Contenu de la page Contact attendu.");
                break;
            case "connexion":
            case "login":
                Assert.True(await _pages.Login.IsDisplayedAsync(), "Contenu de la page de connexion attendu.");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(pageName), pageName, "Page inconnue.");
        }
    }
}
