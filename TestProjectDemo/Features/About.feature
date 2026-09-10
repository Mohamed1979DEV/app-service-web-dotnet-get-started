# language: fr
Fonctionnalité: Page A propos
  En tant qu utilisateur authentifie
  Je veux consulter la page A propos
  Afin de lire la description de l application

  Contexte:
    Étant donné que je suis authentifie en tant que "admin" avec le mot de passe "admin"

  Scénario: La page A propos affiche la description
    Quand je ouvre la page apropos
    Alors je suis sur la page apropos
    Et je vois le titre "About."
    Et je vois le texte "Your application description page."
    Et le titre de la page contient "About"

  Scénario: Navigation vers A propos depuis la barre de navigation
    Étant donné que je ouvre la page accueil
    Quand je clique sur le lien "About"
    Alors je suis sur la page apropos

  Scénario: Un utilisateur non authentifie est redirige vers la connexion depuis A propos
    Étant donné que je ne suis pas authentifie
    Quand je ouvre la page apropos
    Alors la page de connexion est affichee
