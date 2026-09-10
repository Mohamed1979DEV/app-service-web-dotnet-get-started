# CI / CD

## Objectif

| Besoin | Solution |
|--------|----------|
| Build + tests Playwright/Reqnroll + rapport | Workflow `CI - Build, Tests & Report` |
| Consulter le rapport HTML | Artefact GitHub Actions + **GitHub Pages** (rapport uniquement) |
| Heberger l'application ASP.NET MVC 4.8 | **Azure App Service** (Windows) via workflow `CD - Deploy to Azure App Service` |

> **Important :** GitHub Pages ne peut **pas** heberger une application ASP.NET Framework (IIS / .NET 4.8). Pages ne sert qu'aux fichiers statiques (ici le rapport de tests).

## Workflows

### 1. `.github/workflows/ci.yml`

Declenchement : push sur `main` / `Test` / `Cursor`, pull requests vers `main`, ou manuel.

Etapes :
1. Restore + build MSBuild de `aspnet-get-started`
2. Publication filesystem + demarrage **IIS Express** sur le runner Windows
3. Execution des tests `TestProjectDemo` (Reqnroll + Playwright) contre `http://localhost:8080`
4. Generation du rapport HTML Reqnroll (`test-results/`)
5. Upload des artefacts `test-results` et `aspnet-get-started-site`
6. Publication du rapport sur **GitHub Pages** (branches `main` et `Test`)

### 2. `.github/workflows/deploy-azure.yml`

Declenchement : push sur `main` (chemins web) ou manuel.

Necessite dans le depot GitHub :
- **Variable** `AZURE_WEBAPP_NAME` : nom de votre App Service
- **Secret** `AZURE_WEBAPP_PUBLISH_PROFILE` : profil de publication Azure (XML)

#### Creer l'App Service (resume)

1. Portail Azure → App Service → Windows + runtime **ASP.NET V4.8**
2. Deployment Center / Get publish profile → telecharger le `.PublishSettings`
3. GitHub → Settings → Secrets and variables → Actions  
   - Secret : `AZURE_WEBAPP_PUBLISH_PROFILE` = contenu du fichier  
   - Variable : `AZURE_WEBAPP_NAME` = nom de l'app

## Activer GitHub Pages (rapport)

1. Repo → **Settings** → **Pages**
2. Source : **GitHub Actions**
3. Settings → Secrets and variables → Actions → **Variables**
4. Creer `ENABLE_GITHUB_PAGES` = `true`

Sans cette variable, le job Pages est ignore (evite l'erreur `Not Found` si Pages n'est pas configure).

Apres un run CI reussi, le rapport est aussi toujours dans **Artifacts** → `test-results`.

## Rapport local

```powershell
dotnet test TestProjectDemo
# Rapport : TestProjectDemo\bin\Debug\net10.0\test-results\reqnroll-report.html
```

Configurer l'URL cible via `TestProjectDemo/appsettings.json` ou la variable d'environnement `BASE_URL`.

## Credentials de demo

Login applicatif (config `Web.config`) : `admin` / `admin`  
A changer avant toute mise en production.
