module App

open Browser.Dom
open Fable.React
open Fable.React.Props

let TodoApp =
    FunctionComponent.Of<unit>
        (fun props ->
            let state = Hooks.useState (0)

            span [ OnClick(fun _ -> state.update (state.current + 1)) ] [
                str <| sprintf "hello world, %i" state.current
            ])

let render () =
    ReactDom.render (TodoApp(), document.getElementById ("app"))

render ()
