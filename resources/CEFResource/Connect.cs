using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;

namespace CEFResource
{
    public class Connect : Script
    {
        public Connect()
        {
            API.onPlayerConnected += API_onPlayerConnected;
            API.onPlayerFinishedDownload += API_onPlayerFinishedDownload;
        }

        private void API_onPlayerConnected(Client player)
        {
            //API.setEntityDimension(player, -1);
            //API.freezePlayer(player, true);
            API.setPlayerSkin(player, PedHash.FreemodeMale01);
        }

        private void API_onPlayerFinishedDownload(Client player)
        {
            API.triggerClientEvent(player, "ShowLogin");
        }
    }
}
