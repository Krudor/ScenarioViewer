using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Model.Files;

namespace ScenarioViewer
{
    public interface IDBCDataProvider
    {
        Criteria GetCriteria(uint id);
        CriteriaTree GetCriteriaTree(uint id);
        Scenario GetScenario(uint id);
        ScenarioStep GetScenarioStep(uint id);
        DungeonEncounter GetDungeonEncounter(uint id);
        Item GetItem(uint id);
        Spell GetSpell(uint id);
    }
}
