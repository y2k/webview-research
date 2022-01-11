open PhotinoNET

PhotinoWindow()
    .SetTitle("TODO List")
    .SetSize(500, 600)
    .RegisterWebMessageReceivedHandler(fun _ message -> printfn "LOG: called from web %O" message)
    .Load("../web/public/index.html")
    .WaitForClose()
