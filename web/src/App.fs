module App

open System
open Browser.Dom
open Fable.React
open Fable.React.Props
open Fulma
open Fable.Core

type External =
    abstract invoke : _ -> unit

[<Global>]
let external : External = jsNative

let TodoApp =
    let removeAt index xs =
        xs
        |> Seq.indexed
        |> Seq.filter (fun (i, _) -> i <> index)
        |> Seq.map snd
        |> Seq.toList

    FunctionComponent.Of<unit>
        (fun props ->
            let text = Hooks.useState ("")
            let state = Hooks.useState ([])

            Box.box' [] [
                Field.div [] [
                    Label.label [] [ str "Новая запись" ]
                    Control.div [] [
                        Input.input [ Input.Type Input.IInputType.Email
                                      Input.Value text.current
                                      Input.OnChange(fun x -> text.update x.Value) ]
                    ]
                ]
                Button.button [ Button.Disabled(String.IsNullOrWhiteSpace text.current)
                                Button.OnClick
                                    (fun _ ->
                                        state.update (fun xs -> text.current :: xs)
                                        text.update "") ] [
                    str "Добавить"
                ]
                Button.button [ Button.OnClick(fun _ -> external.invoke "6") ] [
                    str "Call native"
                ]
                div [ Style [ Height 20 ] ] []
                yield!
                    state.current
                    |> List.mapi
                        (fun index x ->
                            Notification.notification [] [
                                Delete.delete [ Delete.OnClick(fun _ -> state.update (removeAt index)) ] []
                                str x
                            ])
            ])

let render () =
    ReactDom.render (TodoApp(), document.getElementById ("app"))

render ()
