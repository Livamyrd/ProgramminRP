using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared.Math;
using System.Data;

namespace CEFResource
{
    public class Connect : Script
    {
        System.Data.SqlClient.SqlConnection connection;
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


        }

        private void API_onPlayerFinishedDownload(Client player)
        {
            API.setEntityDimension(player, -1);
            API.freezePlayer(player, true);
            API.setEntityInvincible(player, true);


            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\GTMP\\Server\\ProgramminRP\\ProgramminRP\\LocalDb.mdf;Integrated Security=True";

            using (connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM [dbo].[user]", connection))
            {
                DataTable userTable = new DataTable();
                adapter.Fill(userTable);

                foreach (DataRow row in userTable.Rows)
                {
                    API.sendChatMessageToPlayer(player, "Your name is " + row.Field<string>("Name"));
                }
            }

            API.triggerClientEvent(player, "createLoginCamera", cameraPositionVinewoodSign.X, cameraPositionVinewoodSign.Y, cameraPositionVinewoodSign.Z);
        }

        public void OnClientTriggered(Client player, string eventName,
            params object[] arguments)
        {
            switch (eventName)
            {
                case "TryLogin":
                    API.setEntityDimension(player, 0);
                    API.freezePlayer(player, false);
                    API.sendNotificationToPlayer(player,
                        "Login Correcto.");
                    break;
            }
        }
    }
}
