module App.PageViews
open Fulma
open Fable.React.Props
open Fable.React.Helpers
open Fable.React.Standard
open Fulma
open Router
open System

let strl en br = function
    | EN -> str en
    | BR -> str br

let home lang =


    Card.card [][
        Card.header [][
            Card.Header.title[Card.Header.Title.IsCentered][
                strl "About me" "Sobre mim" lang
            ]
        ]
        Card.content [][
         Columns.columns[
             ][
          Column.column[
               Column.Width( Screen.All,Column.Is2)
               ][
              Image.image[Image.IsSquare][
                  img [Src "assets/bitmoji.png"]
              ]
          ]
          Column.column[
              Column.Modifiers[Modifier.TextAlignment (Screen.All, TextAlignment.Justified)]
              Column.Width( Screen.All,Column.Is10)
              ][
           Content.content [][
            span [] [strl "Hi! My name is Diego and " "Olá, meu nome é Diego e " lang]
            span [] [

                (
                 let d = DateTime.Today
                 let years = d.Year - 1992 - (if d.Month < 11 && d.Day < 19 then 1 else 0)
                 if d.Day = 19 && d.Month = 11 then
                    strl
                        (sprintf "today is my birthday! I'm turning %i today. Yay me! " years)
                        (sprintf "hoje é meu aniversário! Estou fazendo %i anos. Bora pro bar! " years)
                        lang
                 else
                    strl
                        (sprintf "I'm %i years old. " years)
                        (sprintf "tenho %i anos. " years)
                        lang)]
            span [][
                    strl
                        "I've been programming since I was a little kid, with a spark from Cheat Engine because I wasn't a good enough player. Then I used to create some cheats for games. Now I do things that are a little less destructive, but I'm glad that that made me learn everything I know today."
                        "Eu programo desde pequeno, aprendendo a lógica mexendo com o Cheat Engine porque eu era um n00b dos joguinhos. Antigamente programava alguns hacks para jogos. Agora eu faço coisas um pouco menos destrutivas, mas o aprendizado dessa época foi a base para tudo que sei."
                        lang
                ]
            ]

        ]

        ]
        ]
  ]


let fsharp lang =
    Container.container [] [
        Heading.h1 [][
            str (match lang with Router.EN -> "Under construction. Be sure to come back soon!" | Router.BR -> "Em construção. Volte logo!")
        ]
    ]
let csharp = fsharp
let java = fsharp

let view lang = function
    | Router.Home -> home lang
    | Router.Lang Router.Java -> java lang
    | Router.Lang Router.CSharp -> csharp lang
    | Router.Lang Router.FSharp -> fsharp lang