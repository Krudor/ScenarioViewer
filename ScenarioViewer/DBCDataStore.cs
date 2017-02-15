using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Model.Files;

namespace ScenarioViewer
{
    public class DBCDataStore : IDBCDataProvider
    {
        public Dictionary<uint, Criteria> Criterias { get; set; }
        public Dictionary<uint, CriteriaTree> CriteriaTrees { get; set; }
        public Dictionary<uint, Scenario> Scenarios { get; set; }
        public Dictionary<uint, ScenarioStep> ScenarioSteps { get; set; }
        public Dictionary<uint, DungeonEncounter> DungeonEncounters { get; set; }
        public Dictionary<uint, Item> Items { get; set; }
        public Dictionary<uint, Spell> Spells { get; set; }

        public DBCDataStore()
        {
            Criterias = new Dictionary<uint, Criteria>();
            CriteriaTrees = new Dictionary<uint, CriteriaTree>();
            Scenarios = new Dictionary<uint, Scenario>();
            ScenarioSteps = new Dictionary<uint, ScenarioStep>();
            DungeonEncounters = new Dictionary<uint, DungeonEncounter>();
            Items = new Dictionary<uint, Item>();
            Spells = new Dictionary<uint, Spell>();
        }

        public void Add(Criteria criteria)
        {
            if (Criterias.ContainsKey(criteria.Id))
                return;

            Criterias.Add(criteria.Id, criteria);
        }

        public void Add(CriteriaTree criteriaTree)
        {
            if (CriteriaTrees.ContainsKey(criteriaTree.Id))
                return;

            CriteriaTrees.Add(criteriaTree.Id, criteriaTree);
        }

        public void Add(Scenario scenario)
        {
            if (Scenarios.ContainsKey(scenario.Id))
                return;

            Scenarios.Add(scenario.Id, scenario);
        }

        public void Add(ScenarioStep scenarioStep)
        {
            if (ScenarioSteps.ContainsKey(scenarioStep.Id))
                return;

            ScenarioSteps.Add(scenarioStep.Id, scenarioStep);
        }

        public void Add(DungeonEncounter dungeonEncounter)
        {
            if (DungeonEncounters.ContainsKey(dungeonEncounter.Id))
                return;

            DungeonEncounters.Add(dungeonEncounter.Id, dungeonEncounter);
        }

        public void Add(Item item)
        {
            if (Items.ContainsKey(item.Id))
                return;

            Items.Add(item.Id, item);
        }

        public void Add(Spell spell)
        {
            if (Spells.ContainsKey(spell.Id))
                return;

            Spells.Add(spell.Id, spell);
        }

        public Criteria GetCriteria(uint id) => Criterias.ContainsKey(id) ? Criterias[id] : null;
        public CriteriaTree GetCriteriaTree(uint id) => CriteriaTrees.ContainsKey(id) ? CriteriaTrees[id] : null;
        public Scenario GetScenario(uint id) => Scenarios.ContainsKey(id) ? Scenarios[id] : null;
        public ScenarioStep GetScenarioStep(uint id) => ScenarioSteps.ContainsKey(id) ? ScenarioSteps[id] : null;
        public DungeonEncounter GetDungeonEncounter(uint id) => DungeonEncounters.ContainsKey(id) ? DungeonEncounters[id] : null;
        public Item GetItem(uint id) => Items.ContainsKey(id) ? Items[id] : null;
        public Spell GetSpell(uint id) => Spells.ContainsKey(id) ? Spells[id] : null;
    }
}
