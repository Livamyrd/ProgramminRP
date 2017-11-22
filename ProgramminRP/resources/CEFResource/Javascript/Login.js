var browser = null;
function TestHandler() {
    
}

function LoginScreen(args)
{
    var res = API.getScreenResolution();
    var position = args[0];
    var vinewoodCam = API.createCamera(position);

    API.setActiveCamera(vinewoodCam);

    browser = API.createCefBrowser(500, 499);
    API.waitUntilCefBrowserInit(browser);

    API.setCefBrowserPosition(browser, res.Width / 2
        - 500 / 2, res.Height / 2 - 499 / 2);

    API.loadPageCefBrowser(browser, "Designs/index.html");
    API.showCursor(true);
    API.setCanOpenChat(false);
}

function LoginClicked() { 
    API.showCursor(false);
    API.setCanOpenChat(true);
    API.destroyCefBrowser(browser);

    API.triggerServerEvent("TryLogin");
}
