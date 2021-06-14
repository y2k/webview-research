use web_view::Content;
use web_view::WebViewBuilder;

fn main() {
    WebViewBuilder::new()
        .title("TODO List")
        .content(Content::Url(
            "file:///Users/igor/Projects/webview-example/web/public/index.html",
        ))
        .size(480, 570)
        .resizable(false)
        .debug(true)
        .user_data(())
        .invoke_handler(|_webview, arg| {
            println!("Called from JS: {0}", arg);
            Ok(())
        })
        .build()
        .unwrap()
        .run()
        .unwrap();
}
