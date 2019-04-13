module App.View

open Elmish
open Fable.React
open Fable.React.Props
open State
open Types
open Fulma
open Fable.FontAwesome
open Fulma
open System.ComponentModel

let private navbarEnd =
    Navbar.End.div [ ]
        [ Navbar.Item.div [ ]
            [ Field.div [ Field.IsGrouped ]
                [ Control.p [ ]
                    [ Button.a [ Button.Props [ Href "https://twitter.com/DiEsmerio" ] ]
                        [ Icon.icon [ ]
                            [ Fa.i [ Fa.Brand.Twitter ] [ ] ]
                          span [ ] [ str "Twitter" ] ] ] ] ] ]

let private navbarStart lang dispatch =
    Navbar.Start.div [ ]
        [ Navbar.Item.div [ Navbar.Item.HasDropdown
                            Navbar.Item.IsHoverable ]
            [ Navbar.Link.div [ ]
                [ str (match lang with
                       |Router.EN -> "Language"
                       |Router.BR -> "Linguagem") ]
              Navbar.Dropdown.div [ ]
                [ Navbar.Item.a [ Navbar.Item.Props [ OnClick (fun _ -> dispatch (SetLanguage Router.EN))] ]
                    [ str "English" ]
                  Navbar.Item.a [ Navbar.Item.Props [ OnClick (fun _ -> dispatch (SetLanguage Router.BR))] ]
                    [ str "Português" ] ] ] ]

let private navbarView lang isBurgerOpen dispatch =
    div [ ClassName "navbar-bg" ]
        [ Container.container [ ]
            [ Navbar.navbar [ Navbar.CustomClass "is-primary" ]
                [ Navbar.Brand.div [ ]
                    [ Navbar.Item.a [ Navbar.Item.Props [ Href ("#"+(Router.fromL10N lang)) ] ]
                        [ Image.image [ Image.Is32x32 ]
                            [ img [ Src "assets/me.webp" ] ]
                          Heading.p [ Heading.Is4 ]
                            [ str "Diego Esmerio" ] ]
                      // Icon display only on mobile
                      Navbar.Item.a [ Navbar.Item.Props [ Href "https://twitter.com/DiEsmerio" ]
                                      Navbar.Item.CustomClass "is-hidden-desktop" ]
                                    [ Icon.icon [ ]
                                        [ Fa.i [ Fa.Brand.Twitter
                                                 Fa.Size Fa.FaLarge ] [ ] ] ]
                      // Make sure to have the navbar burger as the last child of the brand
                      Navbar.burger [ Fulma.Common.CustomClass (if isBurgerOpen then "is-active" else "")
                                      Fulma.Common.Props [
                                        OnClick (fun _ -> dispatch ToggleBurger) ] ]
                        [ span [ ] [ ]
                          span [ ] [ ]
                          span [ ] [ ] ] ]
                  Navbar.menu [ Navbar.Menu.IsActive isBurgerOpen ]
                    [ navbarStart lang dispatch
                      navbarEnd ] ] ] ]

let private renderPage model dispatch =
    match model with
    | { CurrentPage = Router.Translated(lang,page) } ->
        Hero.hero [Hero.IsFullHeight] [
          Hero.head [Props[Style[Top "0";ZIndex "30";Position Position.Sticky]]][
            navbarView lang model.IsBurgerOpen dispatch
          ]
          Hero.body[][
            PageViews.view lang page
          ]
          Hero.foot [Props[Style[Bottom "0";Position Position.Sticky]]][
            Tabs.tabs[
               Tabs.IsCentered
               Tabs.IsFullWidth
               Tabs.IsBoxed][
                 Tabs.tab[Tabs.Tab.IsActive (page = Router.Home)][Button.a [Button.OnClick (fun _ -> dispatch (SetPage (Router.Home)))][str (match lang with Router.EN -> "Home"| Router.BR -> "Início")]]
                 Tabs.tab[Tabs.Tab.IsActive (page = (Router.Lang Router.FSharp))][Button.a [Button.OnClick (fun _ -> dispatch (SetPage (Router.Lang Router.FSharp)))][str "F#"]]
                 Tabs.tab[Tabs.Tab.IsActive (page = (Router.Lang Router.CSharp))][Button.a [Button.OnClick (fun _ -> dispatch (SetPage (Router.Lang Router.CSharp)))][str "C#"]]
                 Tabs.tab[Tabs.Tab.IsActive (page = (Router.Lang Router.Java))][Button.a [Button.OnClick (fun _ -> dispatch (SetPage (Router.Lang Router.Java)))][str "Java"]]
               ]
          ]
        ]
    | { CurrentPage = Router.Landing } ->
        div [][
          Hero.hero [Hero.IsFullHeight][
           Hero.head[][]
           Hero.body[][
             Level.level[
               Level.Level.Props[Style[Width "100vw"]]
               Level.Level.IsMobile
             ][

                Level.item[Level.Item.HasTextCentered][
                 Level.heading[Props [OnClick (fun _ -> dispatch (SetLanguage Router.BR)) ]][
                  Image.image [Image.Is128x128][
                    str "Português"
                    img [Src "assets/br.svg"]
                  ]
                 ]
                ]
                Level.item[Level.Item.HasTextCentered][
                 Level.heading[Props [OnClick (fun _ -> dispatch (SetLanguage Router.EN)) ]][
                  Image.image [Image.Is128x128][
                    str "English"
                    img [Src "assets/us.svg"]
                  ]
                 ]
             ]
             ]
            ]
           Hero.foot [][
              Container.container [Container.IsFluid; Container.Modifiers [Modifier.TextAlignment (Screen.All, TextAlignment.Centered)]][
               span[][str "Made with "]
               span[][a[Href "https://fable.io"][str "Fable"]]
               span[][str ", "]
               span[][a[Href "https://fulma.github.io/Fulma"][str "Fulma"]]
               span[][str " and "]
               span[][a[Href "https://elmish.github.io/"][str "Elmish"]]
              ]
           ]
          ]
        ]
    | _ ->
        div [] []

let private root model dispatch =
    div [ ]
        [ renderPage model dispatch ]


open Elmish.React
open Elmish.Debug
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.HMR

// Init the first datas into the database

Program.mkProgram init update root
|> Program.toNavigable (parseHash Router.pageParser) urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
