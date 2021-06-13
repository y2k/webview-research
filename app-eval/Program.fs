open SharpWebview
open SharpWebview.Content

[<EntryPoint>]
let main argv =
    use webview = new Webview(true, true)

    webview
        .SetTitle("TODO List")
        .SetSize(500, 800, WebviewHint.None)
        .Bind(
            "evalTest",
            fun id req ->
                printfn "Data from JS, id = %O, req = %O" id req
                webview.Return(id, RPCResult.Success, "{ result: 42 }")
        )
        // .Navigate(UrlContent("http://localhost:8080/"))
        .Navigate(UrlContent("file:///Users/igor/Projects/webview-example/web/public/index.html"))
        .Run()
    |> ignore

    0
