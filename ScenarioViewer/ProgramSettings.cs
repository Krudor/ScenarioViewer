using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioViewer
{
    public static class ProgramSettings
    {
        public static bool UseDungeonEncounters
        {
            get
            {
                return Properties.Settings.Default.UseDungeonEncounters;
            }
            set
            {
                Properties.Settings.Default.UseDungeonEncounters = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool UseItems
        {
            get
            {
                return Properties.Settings.Default.UseItems;
            }
            set
            {
                Properties.Settings.Default.UseItems = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool UseSpells
        {
            get
            {
                return Properties.Settings.Default.UseSpells;
            }
            set
            {
                Properties.Settings.Default.UseSpells = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool VerboseCriteriaTree
        {
            get { return Properties.Settings.Default.VerboseCriteriaTree; }
            set
            {
                Properties.Settings.Default.VerboseCriteriaTree = value;
                Properties.Settings.Default.Save();
            }
        }
        
        public static string DBUsername
        {
            get { return Properties.Settings.Default.DBUsername; }
            set
            {
                Properties.Settings.Default.DBUsername = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DBPassword
        {
            get { return Properties.Settings.Default.DBPassword; }
            set
            {
                Properties.Settings.Default.DBPassword = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DBDatabase
        {
            get { return Properties.Settings.Default.DBDatabase; }
            set
            {
                Properties.Settings.Default.DBDatabase = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DBServer
        {
            get { return Properties.Settings.Default.DBServer; }
            set
            {
                Properties.Settings.Default.DBServer = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string DBPort
        {
            get { return Properties.Settings.Default.DBPort; }
            set
            {
                Properties.Settings.Default.DBPort = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool UseCreatureNames
        {
            get { return Properties.Settings.Default.UseCreatureNames; }
            set
            {
                Properties.Settings.Default.UseCreatureNames = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool UseGameobjectNames
        {
            get { return Properties.Settings.Default.UseGameobjectNames; }
            set
            {
                Properties.Settings.Default.UseGameobjectNames = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool CriteriaTreeClickTriggersWowhead
        {
            get { return Properties.Settings.Default.CriteriaTreeClickTriggersWowhead; }
            set
            {
                Properties.Settings.Default.CriteriaTreeClickTriggersWowhead = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
