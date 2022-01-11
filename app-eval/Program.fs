open System.IO
open SharpWebview
open SharpWebview.Content

[<EntryPoint>]
let main _ =
    let path = Path.GetFullPath "../web/public/index.html"
    use webview = new Webview(true, true)

    webview
        .SetTitle("TODO List")
        .SetSize(500, 600, WebviewHint.None)
        .Bind(
            "invoke",
            fun id req ->
                printfn "Data from JS, id = %O, req = %O" id req
                webview.Return(id, RPCResult.Success, "{ result: 42 }")
        )
        .Navigate(UrlContent $"file://{path}")
        .Run()
    |> ignore

    0
