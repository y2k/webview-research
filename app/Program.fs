open System
open System.Drawing
open System.IO
open Webview

[<EntryPoint>]
let main _ =
    let path = Path.GetFullPath "../web/public/index.html"

    WebviewBuilder("TODO List", Content.FromUri(Uri $"file://{path}"))
        .WithSize(Size(500, 600))
        .WithInvokeCallback(fun _ payload -> printfn "Called from JS: %s" payload)
        .Debug()
        .Build()
        .Run()

    0
