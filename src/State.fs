module App.State

open Fable.Core
open Browser
open Elmish
open Types


let urlUpdate (result: Option<Router.LocalizatedPage>) model =
    match result with
    | None ->

        JS.console.error("Error parsing url: " + window.location.href)
        model, Router.modifyUrl model.CurrentPage

    | Some page ->
        { model with CurrentPage = page }, Cmd.none


let init result =
    urlUpdate result Model.Empty

let update msg model =
    match (msg, model) with
    | ToggleBurger, _ ->
        { model with IsBurgerOpen = not model.IsBurgerOpen }, Cmd.none
    | SetLanguage l, {CurrentPage = Router.Translated (_,p)} ->
        let np = Router.Translated (l,p)
        { model with CurrentPage = np}, Router.modifyUrl np
    | SetLanguage l, {CurrentPage = Router.Unsupported | Router.Landing} ->
        let np = Router.Translated (l, Router.Home)
        { model with CurrentPage = np}, Router.modifyUrl np
    | SetPage p, {CurrentPage = Router.Translated(l,_)} ->
        let np = Router.Translated (l,p)
        { model with CurrentPage = np}, Router.modifyUrl np
    | SetPage _, {CurrentPage = Router.Unsupported | Router.Landing} ->
        let np = Router.Landing
        { model with CurrentPage = np}, Router.modifyUrl np