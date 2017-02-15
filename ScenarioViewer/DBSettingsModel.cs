using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioViewer
{
    public class DBSettingsModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }

        public static DBSettingsModel FromSettings()
        {
            return new DBSettingsModel
            {
                Username = ProgramSettings.DBUsername,
                Password = ProgramSettings.DBPassword,
                Database = ProgramSettings.DBDatabase,
                Server = ProgramSettings.DBServer,
                Port = ProgramSettings.DBPort,
            };
        }

        public void Save()
        {
            if (ProgramSettings.DBUsername != Username)
                ProgramSettings.DBUsername = Username;

            if (ProgramSettings.DBPassword != Password)
                ProgramSettings.DBPassword = Password;

            if (ProgramSettings.DBDatabase != Database)
                ProgramSettings.DBDatabase = Database;

            if (ProgramSettings.DBServer != Server)
                ProgramSettings.DBServer = Server;

            if (ProgramSettings.DBPort != Port)
                ProgramSettings.DBPort = Port;
        }
    }
}
