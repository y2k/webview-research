open System
open Webview
open System.Drawing

[<EntryPoint>]
let main argv =
    WebviewBuilder(
        "TODO List",
        Content.FromUri(Uri "file:///Users/igor/Projects/webview-example/web/public/index.html")
    )
        .WithSize(Size(500, 600))
        .WithInvokeCallback(fun _ payload -> printfn "Called from JS: %s" payload)
        .Debug()
        .Build()
        .Run()

    0
