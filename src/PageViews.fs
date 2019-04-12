module App.PageViews
open Fulma
open Fable.React.Helpers

let home lang =
    Container.container [] [
        Heading.h1 [][
            str (match lang with Router.EN -> "Under construction. Be sure to come back soon!" | Router.BR -> "Em construção. Volte logo!")
        ]
    ]

let fsharp = home
let csharp = home
let java = home

let view lang = function
    | Router.Home -> home lang
    | Router.Lang Router.Java -> java lang
    | Router.Lang Router.CSharp -> csharp lang
    | Router.Lang Router.FSharp -> fsharp lang