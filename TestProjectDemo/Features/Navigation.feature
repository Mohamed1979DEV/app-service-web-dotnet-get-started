# language: fr
Fonctionnalité: Navigation du site
  En tant qu utilisateur authentifie
  Je veux naviguer entre toutes les pages de l application
  Afin d atteindre Accueil, A propos, Contact et Connexion/Deconnexion

  Contexte:
    Étant donné que je suis authentifie en tant que "admin" avec le mot de passe "admin"
    Et que je ouvre la page accueil

  Plan du scénario: Navigation vers une page depuis la barre de navigation
    Quand je clique sur le lien "<Lien>"
    Alors je suis sur la page <Page>
    Et le titre de la page contient "<Titre>"

    Exemples:
      | Lien    | Page    | Titre     |
      | Home    | accueil | Home Page |
      | About   | apropos | About     |
      | Contact | contact | Contact   |

  Scénario: Le lien de la marque ramene a l accueil
    Étant donné que je ouvre la page apropos
    Quand je clique sur le lien "Application name"
    Alors je suis sur la page accueil

  Scénario: Parcours de navigation complet sur toutes les pages
    Quand je clique sur le lien "About"
    Alors je suis sur la page apropos
    Quand je clique sur le lien "Contact"
    Alors je suis sur la page contact
    Quand je clique sur le lien "Home"
    Alors je suis sur la page accueil
    Quand je clique sur le lien "Logout"
    Alors la page de connexion est affichee
