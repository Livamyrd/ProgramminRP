using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using System.Data.SqlClient;
using System.Data;
using GrandTheftMultiplayer.Shared.Math;

namespace CEFResource
{
    public class Connect : Script
    {
        SqlConnection connection;
        string connectionString;

        private readonly Vector3 cameraPositionVinewoodSign = new Vector3(695.5733, 955.9597, 380.969);

        public Connect()
        {
            API.onPlayerConnected += API_onPlayerConnected;
            API.onPlayerFinishedDownload += API_onPlayerFinishedDownload;
            API.onClientEventTrigger += OnClientTriggered;
        }

        private void API_onPlayerConnected(Client player)
        {
            
            API.setPlayerSkin(player, PedHash.FreemodeMale01);

             connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename=D:\\Fernando\\GT-MP\\ProgramminRP\\LocalDb.mdf;Integrated Security=True";

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM user", connection))
            {
                DataTable userTable = new DataTable();
                adapter.Fill(userTable);

                foreach(DataRow row in userTable.Rows)
                {
                    API.sendChatMessageToPlayer(player, "Your name is " + row.Field<string>("Name"));
                }
            }

        }

        private void API_onPlayerFinishedDownload(Client player)
        {
            API.setEntityDimension(player, -1);
            API.freezePlayer(player, true);
            API.setEntityInvincible(player, true);
            API.triggerClientEvent(player, "createLogin", cameraPositionVinewoodSign);
        }

        public void OnClientTriggered(Client player, string eventName,
            params object[] arguments)
        {
            switch (eventName)
            {
                case "TryLogin":
                    API.sendNotificationToPlayer(player,
                        "We're back where we started.");
                    break;
            }
        }
    }
}
