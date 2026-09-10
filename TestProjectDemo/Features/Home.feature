# language: fr
Fonctionnalité: Page d accueil
  En tant qu utilisateur authentifie
  Je veux consulter la page d accueil
  Afin de voir le contenu principal de l application

  Contexte:
    Étant donné que je suis authentifie en tant que "admin" avec le mot de passe "admin"

  Scénario: La page d accueil affiche le contenu principal
    Quand je ouvre la page accueil
    Alors je suis sur la page accueil
    Et je vois le titre "ASP.NET"
    Et je vois le titre "Getting started"
    Et le titre de la page contient "Home Page"

  Scénario: Un utilisateur non authentifie est redirige vers la connexion depuis l accueil
    Étant donné que je ne suis pas authentifie
    Quand je ouvre la page accueil
    Alors la page de connexion est affichee
