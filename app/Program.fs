open System
open Webview
open System.Drawing

[<EntryPoint>]
let main argv =
    Webview.Simple("TODO List", Content.FromUri(Uri "http://localhost:8080/"), Size(500, 600), false)
    0
