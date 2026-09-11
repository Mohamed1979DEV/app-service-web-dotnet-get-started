# language: fr
Fonctionnalité: Connexion
  En tant que visiteur
  Je veux m authentifier avec un identifiant et un mot de passe
  Afin d acceder aux pages protegees de aspnet-get-started

  Scénario: La page de connexion s affiche
    Quand je ouvre la page de connexion
    Alors la page de connexion est affichee
    Et le titre de la page contient "Login"

  Scénario: Connexion reussie avec des identifiants valides
    Étant donné que je ouvre la page de connexion
    Quand je me connecte avec l utilisateur "admin" et le mot de passe "admin"
    Alors je suis sur la page accueil
    Et je vois le message de bienvenue "Hello, admin"
    Et je vois le lien "Logout"
    Et le bouton "Learn more" s affiche

  Scénario: Echec de connexion avec des identifiants invalides
    Étant donné que je ouvre la page de connexion
    Quand je me connecte avec l utilisateur "admin" et le mot de passe "wrong"
    Alors la page de connexion est affichee
    Et je vois le message d erreur "Invalid username or password."

  Scénario: Echec de connexion avec des champs vides
    Étant donné que je ouvre la page de connexion
    Quand je soumets le formulaire de connexion sans identifiants
    Alors la page de connexion est affichee
    Et je vois des erreurs de validation

  Scénario: La deconnexion ramene a la page de connexion
    Étant donné que je suis authentifie en tant que "admin" avec le mot de passe "admin"
    Quand je clique sur le lien "Logout"
    Alors la page de connexion est affichee
