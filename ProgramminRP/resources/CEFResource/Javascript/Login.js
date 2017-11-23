var browser = null;
function TestHandler() {
    
}

function LoginScreen(args)
{
    var res = API.getScreenResolution();
    var position = args[0];

    API.sendChatMessage("Again: " + args[0] + " " + args[1] + " " + args[2]);
    var cameraPosition = new Vector3(args[0], args[1], args[2]);
    var vinewoodCam = API.createCamera(cameraPosition, new Vector3(0,0,0));
    API.setActiveCamera(vinewoodCam);

    browser = API.createCefBrowser(800, 600);
    API.setCefBrowserPosition(browser,res.Width / 2 - 800 / 2, res.Height / 2 - 600 / 2);

    API.waitUntilCefBrowserInit(browser);



    API.loadPageCefBrowser(browser, "Designs/index.html");
    API.showCursor(true);
    API.setCanOpenChat(false);
}

function LoginClicked() { 
    API.showCursor(false);
    API.setCanOpenChat(true);
    API.destroyCefBrowser(browser);
    API.setGameplayCameraActive();

    API.triggerServerEvent("TryLogin");
}
