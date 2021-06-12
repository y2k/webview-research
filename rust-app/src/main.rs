use web_view::Content;
use web_view::WebViewBuilder;

fn main() {
    WebViewBuilder::new()
        .title("TODO List")
        .content(Content::Url("http://localhost:8080/"))
        .size(480, 570)
        .resizable(false)
        .debug(true)
        .user_data(())
        .invoke_handler(|_webview, _arg| Ok(()))
        .build()
        .unwrap()
        .run()
        .unwrap();
}
