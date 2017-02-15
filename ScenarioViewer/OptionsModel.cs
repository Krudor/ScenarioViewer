using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioViewer
{
    public class OptionsModel
    {
        public DBSettingsModel DBSettingsModel { get; set; }
        public bool UseDungeonEncounter { get; set; }
        public bool UseItems { get; set; }
        public bool UseSpells { get; set; }
        public bool VerboseCriteriaTree { get; set; }
        public bool UseCreatureNames { get; set; }
        public bool UseGameobjectNames { get; set; }
        public bool CriteriaTreeviewClickOpensWowhead { get; set; }

        public static OptionsModel FromSettings()
        {
            return new OptionsModel
            {
                UseDungeonEncounter = ProgramSettings.UseDungeonEncounters,
                UseItems = ProgramSettings.UseItems,
                UseSpells = ProgramSettings.UseSpells,
                VerboseCriteriaTree = ProgramSettings.VerboseCriteriaTree,
                UseCreatureNames = ProgramSettings.UseCreatureNames,
                UseGameobjectNames = ProgramSettings.UseGameobjectNames,
                CriteriaTreeviewClickOpensWowhead = ProgramSettings.CriteriaTreeClickTriggersWowhead,
                DBSettingsModel = new DBSettingsModel
                {
                    Username = ProgramSettings.DBUsername,
                    Password = ProgramSettings.DBPassword,
                    Database = ProgramSettings.DBDatabase,
                    Server = ProgramSettings.DBServer,
                    Port = ProgramSettings.DBPort
                }
            };
        }

        public void SaveToSettings()
        {
            if (ProgramSettings.UseDungeonEncounters != UseDungeonEncounter)
                ProgramSettings.UseDungeonEncounters = UseDungeonEncounter;

            if (ProgramSettings.UseItems != UseItems)
                ProgramSettings.UseItems = UseItems;

            if (ProgramSettings.UseSpells != UseSpells)
                ProgramSettings.UseSpells = UseSpells;

            if (ProgramSettings.VerboseCriteriaTree != VerboseCriteriaTree)
                ProgramSettings.VerboseCriteriaTree = VerboseCriteriaTree;

            if (ProgramSettings.UseCreatureNames != UseCreatureNames)
                ProgramSettings.UseCreatureNames = UseCreatureNames;

            if (ProgramSettings.UseGameobjectNames != UseGameobjectNames)
                ProgramSettings.UseGameobjectNames = UseGameobjectNames;
            
            DBSettingsModel.Save();
        }
    }
}
