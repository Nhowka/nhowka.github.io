module App.Types

type Model =
    { CurrentPage : Router.LocalizatedPage

      IsBurgerOpen : bool }

    static member Empty =
        { CurrentPage = Router.Landing
          IsBurgerOpen = false }

type Msg =
    | SetLanguage of Router.L10N
    | SetPage of Router.Page
    | ToggleBurger
