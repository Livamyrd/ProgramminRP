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

namespace CEFResource
{
    public class Connect : Script
    {
        SqlConnection connection;
        string connectionString;

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
            API.triggerClientEvent(player, "ShowLogin");
        }
    }
}
