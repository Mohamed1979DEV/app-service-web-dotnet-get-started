# language: fr
Fonctionnalité: Page Contact
  En tant qu utilisateur authentifie
  Je veux consulter la page Contact
  Afin de voir les coordonnees de support et marketing

  Contexte:
    Étant donné que je suis authentifie en tant que "admin" avec le mot de passe "admin"

  Scénario: La page Contact affiche l adresse et les emails
    Quand je ouvre la page contact
    Alors je suis sur la page contact
    Et je vois le titre "Contact."
    Et je vois le texte "One Microsoft Way"
    Et je vois le lien "Support@example.com"
    Et je vois le lien "Marketing@example.com"
    Et le titre de la page contient "Contact"

  Scénario: Navigation vers Contact depuis la barre de navigation
    Étant donné que je ouvre la page accueil
    Quand je clique sur le lien "Contact"
    Alors je suis sur la page contact

  Scénario: Un utilisateur non authentifie est redirige vers la connexion depuis Contact
    Étant donné que je ne suis pas authentifie
    Quand je ouvre la page contact
    Alors la page de connexion est affichee
