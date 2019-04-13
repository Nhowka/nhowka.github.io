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
            div[][
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
            div[][
                strl
                    """The first real programming language that I had contact was python.
                    I did some simple math based programs but they were not that useful.
                    So I decided to learn some Windows API using x86 assembly with MASM32.
                    Honestly it's more work but it's not that hard.
                    That made it easier to make code that was injected into the games' code.
                    But then came college I had to learn code-monkey skills.
                    First I was taught C for programming 101 and then Java for object-oriented programming.
                    I hated and dismissed it as not worthy.
                    """
                    """A primeira linguagem de programação de verdade que tive contato foi python.
                    Eu fiz alguns programinhas de calcular IMC e outras coisas com matemática, mas nada de útil.
                    Então eu decidi aprender a API do Windows usando assembly na especificação x86 compinando com o MASM32.
                    Parece difícil mas como usava pra criar código que era injetado nos jogos, era a melhor ferramenta possível.
                    Aí veio a faculdade e eu tive que aprender a programação do dia a dia dos programadores profissionais.
                    Primeiro me ensinaram C como introdução e Java para programação orientada a objetos.
                    Completamente chato e nada a ver!"""
                    lang
            ]
            div[][
                strl
                    """After some time I was doing a research for a logic puzzle game-maker
                    and learned about C#. LINQ was a god-send feature and even with little experience,
                    WPF made the highly dynamic GUI possible. I had found a better Java. I was happy, or at least I thought I was.
                    """
                    """Depois para um projeto de iniciação científica sobre um criador de jogos de lógica eu descobri o C#.
                    LINQ é a melhor coisa que eu podia pedir e mesmo sendo um iniciante na linguagem, com o WPF eu consegui fazer uma
                    interface gráfica super dinâmica para as especificações dos jogos. Era um Java que prestava. Eu estava feliz, ou pelo menos imaginava que sim.
                    """
                    lang
            ]
            div[][
                strl
                    """After a year, I was casually reading some threads on a programming forum and found about F#.
                    I had a LINQPad license, so it was easy to test it.
                    The type-checker on the compiler was beating my ass but when I learned enough it was easier to do it right.
                    And that website is made with F#, with the help of awesome libraries and tools.
                    That's where I found myself and did my most relevant work!
                    """
                    """Um ano depois, eu estava passeando por alguns fóruns de programação quando li sobre o F#.
                    Eu já tinha uma licença do LINQPad, então testar era trivial. Então até aprender de verdade foi uma luta contra o compilador.
                    Hoje é a minha linguagem favorita. Esse mesmo website é feito inteiramente com código F#,
                    com a ajuda de ferramentas e bibliotecas que são puro amor. Meu trabalho mais relevante e minha satisfação estão aqui!"""
                    lang
            ]

            ]

        ]

        ]
        ]
        Card.footer[][
            Card.Footer.div[][strl "Sadly, it is Java that pays my bills..." "Infelizmente é o Java que paga minhas contas..." lang]
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