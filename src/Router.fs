module Router

open Browser
open Fable.React.Props
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.Browser

type L10N =
    | EN
    | BR


type Langs =
    | FSharp
    | CSharp
    | Java

type Page =
    | Lang of Langs
    | Home

type LocalizatedPage =
    | Translated of L10N * Page
    | Landing
    | Unsupported

let toL10N = function "en" -> Some EN | "br" -> Some BR | _ -> None
let fromL10N = function EN -> "en" | BR -> "br"

let private toHash page =
   match page with
   | Unsupported -> "#notavailable"
   | Translated (l10n, page) ->
    fromL10N l10n
    |>
    (match page with
     | Lang langPage ->
        match langPage with
        | FSharp -> sprintf "#%s/lang/fsharp"
        | CSharp -> sprintf "#%s/lang/csharp"
        | Java -> sprintf "#%s/lang/java"
     | Home -> sprintf "#%s/")
   | Landing -> "#/"

let fromLocalization l = function
    | "en" -> Translated(EN, l)
    | "br" -> Translated(BR, l)
    | _ -> Unsupported

let pageParser: Parser<LocalizatedPage->LocalizatedPage,LocalizatedPage> =
    oneOf [
        map (fromLocalization (Lang FSharp)) ( str </> s "lang" </> s "fsharp")
        map (fromLocalization (Lang CSharp)) ( str </> s "lang" </> s "csharp")
        map (fromLocalization (Lang Java)) ( str </> s "lang" </> s "java")
        map (fromLocalization Home) str
        map Landing top ]

let href route =
    Href (toHash route)

let modifyUrl route =
    route |> toHash |> Navigation.modifyUrl

let newUrl route =
    route |> toHash |> Navigation.newUrl

let modifyLocation route =
    window.location.href <- toHash route
