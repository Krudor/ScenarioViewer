using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScenarioViewer.Utils.Misc
{
    public static class SQLUtils
    {
        public static Dictionary<uint, Tuple<string,string>> GetCreatureNames(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                MySqlCommand command =
                    new MySqlCommand("SELECT `entry`, `Name`, `FemaleName` FROM `creature_template` ORDER BY `entry`",
                        connection);
                MySqlDataReader reader = command.ExecuteReader();
                Dictionary<uint, Tuple<string, string>> creatureNames = new Dictionary<uint, Tuple<string, string>>();
                while (reader.Read())
                {
                    uint entry = reader.GetUInt32(0);
                    string name = reader.GetString(1);
                    string femaleName = reader.GetString(2);
                    creatureNames.Add(entry, new Tuple<string, string>(name, femaleName));
                }

                return creatureNames;
            }
            catch (Exception e)
            {
                return new Dictionary<uint, Tuple<string, string>>();
            }
        }

        public static Dictionary<uint, string> GetGameobjectNames(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                MySqlCommand command =
                    new MySqlCommand("SELECT `entry`, `name` FROM `gameobject_template` ORDER BY `entry`",
                        connection);
                MySqlDataReader reader = command.ExecuteReader();
                Dictionary<uint, string> creatureNames = new Dictionary<uint, string>();
                while (reader.Read())
                {
                    uint entry = reader.GetUInt32(0);
                    string name = reader.GetString(1);
                    creatureNames.Add(entry, name);
                }

                return creatureNames;
            }
            catch (Exception e)
            {
                return new Dictionary<uint, string>();
            }
        }
    }
}
