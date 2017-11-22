API.onServerEventTrigger.connect(function (eventName, args) {
    API.sendChatMessage("Bienvenido de nuevo, " + API.getSocialClubName());
    API.setPlayerSkin(1885233650);
    switch (eventName) {
        case 'testjs':
            resource.CEF.TestHandler();
            break;
        case 'createLoginCamera':
            resource.Login.LoginScreen(args);
            break;
        case 'ShowLogin': 
            resource.Login.LoginScreen();
            break;
    }
});