using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Utils.Misc;

namespace ScenarioViewer
{
    public class DBDataStore : IDBDataProvider
    {
        /// <summary>
        /// Dictionary whos key is creature entry, and value is a Tuple containing male and female name
        /// </summary>
        public Dictionary<uint, Tuple<string, string>> CreatureNames { get; set; }
        public Dictionary<uint, string> GameobjectNames { get; set; }

        public static string ConnectionString()
            =>
                $"Server={ProgramSettings.DBServer};" +
                $"Port={ProgramSettings.DBPort};" +
                $"Database={ProgramSettings.DBDatabase};" +
                $"Uid={ProgramSettings.DBUsername};" +
                $"Pwd={ProgramSettings.DBPassword}";

        public DBDataStore()
        {
            CreatureNames = new Dictionary<uint, Tuple<string, string>>();
            GameobjectNames = new Dictionary<uint, string>();
        }

        public string GetCreatureName(uint entry)
        {
            return CreatureNames.ContainsKey(entry) ? string.IsNullOrEmpty(CreatureNames[entry].Item1) ? CreatureNames[entry].Item2 ?? string.Empty : CreatureNames[entry].Item1 : string.Empty;
        }

        public void LoadCreatureNames()
        {
            CreatureNames = SQLUtils.GetCreatureNames(ConnectionString());
        }

        public string GetGameobjectName(uint entry)
        {
            return GameobjectNames.ContainsKey(entry) ? GameobjectNames[entry] ?? string.Empty : string.Empty;
        }

        public void LoadGameobjectNames()
        {
            GameobjectNames = SQLUtils.GetGameobjectNames(ConnectionString());
        }
    }
}
