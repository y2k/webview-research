open System
open Webview
open System.Drawing

[<EntryPoint>]
let main argv =
    Webview.Simple("Window Title", Content.FromUri(Uri "https://google.com"), Size(500, 600), false)
    0
