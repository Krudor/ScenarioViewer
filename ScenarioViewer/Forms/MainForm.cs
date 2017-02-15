using ScenarioViewer.Model.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ScenarioViewer.Model;
using ScenarioViewer.Model.Readers;
using ScenarioViewer.Properties;
using ScenarioViewer.Utils.Misc;

namespace ScenarioViewer.Forms
{
    public partial class MainForm : Form
    {
        private readonly XmlDocument _mDefinitions;
        private const string DbcLayoutFileName = @"dbclayout.xml";
        private DBCDataStore _dbcDataStore;
        private DBDataStore _dbDataStore;

        private Dictionary<uint, Scenario> Scenarios => _dbcDataStore.Scenarios;

        public string DBCLayoutFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, DbcLayoutFileName);
        public string ScenarioFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, Scenario.FileName);
        public string ScenarioStepFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, ScenarioStep.FileName);
        public string CriteriaFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, Criteria.FileName);
        public string CriteriaTreeFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, CriteriaTree.FileName);
        public string DungeonEncounterFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, DungeonEncounter.FileName);
        public string ItemFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, Item.FileName);
        public string SpellFilePath => Path.Combine(AssemblyUtils.ExecutingAssemblyPath, Item.FileName);

        public MainForm()
        {
            InitializeComponent();

            _mDefinitions = new XmlDocument();

            _dbcDataStore = new DBCDataStore();
            _dbDataStore = new DBDataStore();

            IEnumerable<string> missingFiles = GetMissingFiles();
            if (missingFiles.Any())
            {
                string files = string.Join(", ", missingFiles);
                MessageBox.Show($"One ore more files were not found in the program main directory, please verify the following files exists: \"{files}\"", "Files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Load += (o, e) => Close();
                return;
            }
            _mDefinitions.Load(DBCLayoutFilePath);

            comboBoxScenariosSearchBy.DataSource = Enum.GetValues(typeof(ScenarioSearchType));
        }

        public IEnumerable<string> GetMissingFiles()
        {
            List<string> missingFiles = new List<string>();

            if (!File.Exists(DBCLayoutFilePath))
                missingFiles.Add(Path.GetFileName(DBCLayoutFilePath));

            if (!File.Exists(CriteriaFilePath))
                missingFiles.Add(Path.GetFileName(CriteriaFilePath));

            if (!File.Exists(CriteriaTreeFilePath))
                missingFiles.Add(Path.GetFileName(CriteriaTreeFilePath));

            if (!File.Exists(ScenarioFilePath))
                missingFiles.Add(Path.GetFileName(ScenarioFilePath));

            if (!File.Exists(ScenarioStepFilePath))
                missingFiles.Add(Path.GetFileName(ScenarioStepFilePath));

            if (ProgramSettings.UseDungeonEncounters && !File.Exists(DungeonEncounterFilePath))
                missingFiles.Add(Path.GetFileName(DungeonEncounterFilePath));

            if (ProgramSettings.UseItems && !File.Exists(ItemFilePath))
                missingFiles.Add(Path.GetFileName(ItemFilePath));

            if (ProgramSettings.UseSpells && !File.Exists(SpellFilePath))
                missingFiles.Add(Path.GetFileName(SpellFilePath));

            return missingFiles;
        }

        public IEnumerable<T> LoadDBCObject<T>(Type type, string fileName) where T : IDBObjectReader, new()
        {
            string fullFilePath = Path.Combine(AssemblyUtils.ExecutingAssemblyPath, fileName);
            XmlElement definition = GetDefinition(Path.GetFileNameWithoutExtension(fileName),
                Path.GetFileName(fullFilePath));

            IWowClientDBReader dbReader;
            try
            {
                dbReader = DBReaderFactory.GetReader(fullFilePath, definition);
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show($"Could not get load file \"{fileName}\", make sure it exists in the program root directory", "Load error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                    return LoadDBCObject<T>(type, fileName);

                return new List<T>();
            }

            IList<T> objects = new List<T>();
            foreach (var row in dbReader.Rows)
            {
                T t = new T();
                t.ReadObject(dbReader, row, _dbcDataStore, _dbDataStore);
                objects.Add(t);
            }

            return objects;
        }

        public void LoadCriterias()
        {
            LoadDBCObject<Criteria>(typeof(Criteria), Criteria.FileName).ToList().ForEach(_dbcDataStore.Add);
        }

        public void LoadCriteriaTrees()
        {
            LoadCriterias();

            LoadDBCObject<CriteriaTree>(typeof(CriteriaTree), CriteriaTree.FileName).ToList().ForEach(_dbcDataStore.Add);

            foreach (var criteriaTree in _dbcDataStore.CriteriaTrees)
            {
                if (_dbcDataStore.Criterias.ContainsKey(criteriaTree.Value.CriteriaId))
                    criteriaTree.Value.Criteria = _dbcDataStore.Criterias[criteriaTree.Value.CriteriaId];

                if (_dbcDataStore.CriteriaTrees.ContainsKey(criteriaTree.Value.ParentId))
                {
                    criteriaTree.Value.Parent = _dbcDataStore.CriteriaTrees[criteriaTree.Value.ParentId];
                    _dbcDataStore.CriteriaTrees[criteriaTree.Value.ParentId].Children.Add(criteriaTree.Value);
                }
            }

            // Order criteria tree children by criteria tree child index
            foreach (var criteriaTree in _dbcDataStore.CriteriaTrees)
            {
                criteriaTree.Value.Children = criteriaTree.Value.Children.OrderBy(tree => tree.OrderIndex).ToList();
            }
        }

        public void LoadScenarios()
        {
            LoadCriteriaTrees();
            LoadDBCObject<Scenario>(typeof(Scenario), Scenario.FileName).ToList().ForEach(_dbcDataStore.Add);
            LoadDBCObject<ScenarioStep>(typeof(ScenarioStep), ScenarioStep.FileName).ToList().ForEach(_dbcDataStore.Add);

            foreach (var scenarioStep in _dbcDataStore.ScenarioSteps)
            {
                // Setup Scenario links
                if (_dbcDataStore.Scenarios.ContainsKey(scenarioStep.Value.ScenarioId))
                {
                    _dbcDataStore.Scenarios[scenarioStep.Value.ScenarioId].Steps.Add(scenarioStep.Value);
                    scenarioStep.Value.Scenario = _dbcDataStore.Scenarios[scenarioStep.Value.ScenarioId];
                }

                // Setup Scenario Step links
                if (_dbcDataStore.ScenarioSteps.ContainsKey(scenarioStep.Value.PreviousStepId))
                    scenarioStep.Value.PreviousStep =
                        _dbcDataStore.ScenarioSteps[scenarioStep.Value.PreviousStepId];

                if (_dbcDataStore.ScenarioSteps.ContainsKey(scenarioStep.Value.BonusObjectiveRequiredStepId))
                    scenarioStep.Value.BonusObjectiveRequiredStep =
                        _dbcDataStore.ScenarioSteps[scenarioStep.Value.BonusObjectiveRequiredStepId];

                if (_dbcDataStore.CriteriaTrees.ContainsKey(scenarioStep.Value.CriteriaTreeId))
                    scenarioStep.Value.CriteriaTree = _dbcDataStore.CriteriaTrees[scenarioStep.Value.CriteriaTreeId];
            }

            // Order scenario steps in scenarios by scenario step index
            foreach (var scenario in _dbcDataStore.Scenarios)
            {
                scenario.Value.Steps = scenario.Value.Steps.OrderBy(step => step.StepIndex).ToList();
            }
        }

        public void LoadDungeonEncounters()
            =>
                LoadDBCObject<DungeonEncounter>(typeof(DungeonEncounter), DungeonEncounter.FileName)
                    .ToList()
                    .ForEach(_dbcDataStore.Add);

        public void LoadItems()
        {
            LoadDBCObject<Item>(typeof(Item), Item.FileName)
                .ToList()
                .ForEach(_dbcDataStore.Add);
        }

        public void LoadSpells()
        {
            LoadDBCObject<Spell>(typeof(Spell), Spell.FileName)
                .ToList()
                .ForEach(_dbcDataStore.Add);
        }

        private XmlElement GetDefinition(string dbcName, string dbcNameWithExt)
        {
            XmlNodeList definitions = _mDefinitions["DBFilesClient"].GetElementsByTagName(dbcName);

            if (definitions.Count == 0)
            {
                definitions = _mDefinitions["DBFilesClient"].GetElementsByTagName(dbcNameWithExt);
            }

            if (definitions.Count == 1)
                return (XmlElement) definitions[0];

            return null;
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            LoadScenarios();
            listBoxScenarios.DataSource = _dbcDataStore.Scenarios.Select(scenario => scenario.Value).ToList();
            if (ProgramSettings.UseDungeonEncounters)
                LoadDungeonEncounters();
            if (ProgramSettings.UseItems)
                LoadItems();
            if (ProgramSettings.UseSpells)
                LoadSpells();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Scenario scenario = (Scenario) listBoxScenarios.SelectedItem;
            if (scenario == null)
                return;

            labelScenarioName.Text = scenario.Name;
            textBoxScenarioId.Text = scenario.Id.ToString();
            textBoxScenarioType.Text = $"{(int) scenario.Type} - {scenario.Type.GetDescription()}";
            textBoxScenarioData.Text = scenario.Data.ToString();
            listBoxScenarioFlags.DataSource =
                Enum.GetValues(typeof(ScenarioFlags))
                    .Cast<ScenarioFlags>()
                    .Where(flag => scenario.Flags.HasFlag(flag))
                    .Select(flag => flag.GetDescription()).ToList();
            listBoxScenarioSteps.DataSource = scenario.Steps;
        }

        private void checkBoxScenarioStepBonusObjective_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox) sender;
            if (checkbox == null)
                return;

            if (textBoxScenarioStepRequiredStepId.Text == "0" || string.IsNullOrEmpty(textBoxScenarioStepRequiredStepId.Text))
                return;

            labelScenarioStepRequiredStepId.Visible = checkbox.Checked;
            textBoxScenarioStepRequiredStepId.Visible = checkbox.Checked;
        }

        private void listBoxScenarioSteps_SelectedValueChanged(object sender, EventArgs e)
        {
            ScenarioStep step = (ScenarioStep) listBoxScenarioSteps.SelectedItem;
            if (step == null)
                return;

            labelScenarioStepName.Text = step.Name;
            textBoxScenarioStepDescription.Text = step.Description;
            textBoxScenarioStepId.Text = step.Id.ToString();
            textBoxScenarioStepIndex.Text = step.StepIndex.ToString();
            textBoxScenarioStepQuestRewardId.Text = step.QuestRewardId.ToString();
            linkLabelScenarioStepQuestReward.Visible = !(textBoxScenarioStepQuestRewardId.Text == "0" || string.IsNullOrEmpty(textBoxScenarioStepQuestRewardId.Text));
            textBoxScenarioStepRequiredStepId.Text = step.BonusObjectiveRequiredStepId.ToString();
            checkBoxScenarioStepBonusObjective.Checked = (step.Flags & ScenarioStepFlag.BonusObjective) != 0;
            treeViewScenarioStepCriteriaTrees.Nodes.Clear();
            if (step.CriteriaTree != null)
            {
                treeViewScenarioStepCriteriaTrees.Nodes.AddRange(
                    step.CriteriaTree.GetChildrenTreeNodes(ProgramSettings.VerboseCriteriaTree).ToArray());
                treeViewScenarioStepCriteriaTrees.ExpandAll();
            }
        }
        
        private void buttonSearchScenarios_Click(object sender, EventArgs e)
        {
            ScenarioSearchType searchType = (ScenarioSearchType) comboBoxScenariosSearchBy.SelectedItem;
            switch (searchType)
            {
                case ScenarioSearchType.ByScenarioName:
                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Name?.ToLower(CultureInfo.InvariantCulture)
                                        .Contains(textBoxSearchScenarios.Text.ToLower(CultureInfo.InvariantCulture)) == true)
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
                case ScenarioSearchType.ByScenarioId:
                    int scenarioId;
                    if (!int.TryParse(textBoxSearchScenarios.Text, out scenarioId))
                        break;

                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                            scenario =>
                                scenario.Value.Id == scenarioId).Select(scenario => scenario.Value).ToList();
                    break;
                case ScenarioSearchType.ByScenarioType:
                {
                    int scenarioTypeId;
                    if (!int.TryParse(textBoxSearchScenarios.Text, out scenarioTypeId))
                    {
                        listBoxScenarios.DataSource = SearchByScenarioTypeDescription(textBoxSearchScenarios.Text);
                        break;
                    }

                    ScenarioType type = (ScenarioType) scenarioTypeId;
                    List<Scenario> scenarios = Scenarios.Where(
                        scenario =>
                                scenario.Value.Type == type).Select(scenario => scenario.Value).ToList();

                    if (!scenarios.Any())
                    {
                        listBoxScenarios.DataSource = SearchByScenarioTypeDescription(textBoxSearchScenarios.Text);
                        break;
                    }

                    listBoxScenarios.DataSource = scenarios;
                    break;
 
                }
                case ScenarioSearchType.ByScenarioStepName:
                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Steps.Any(
                                        step =>
                                            step.Name?.ToLower(CultureInfo.InvariantCulture)
                                                .Contains(
                                                    textBoxSearchScenarios.Text.ToLower(CultureInfo.InvariantCulture)) ==
                                            true))
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
                case ScenarioSearchType.ByScenarioStepDescription:
                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Steps.Any(
                                        step =>
                                            step.Description?.ToLower(CultureInfo.InvariantCulture)
                                                .Contains(
                                                    textBoxSearchScenarios.Text.ToLower(CultureInfo.InvariantCulture)) ==
                                            true))
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
                case ScenarioSearchType.UsesCriteriaTreeId:
                    uint criteriaTreeId;
                    if (!uint.TryParse(textBoxSearchScenarios.Text, out criteriaTreeId))
                        break;

                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Steps.Where(step => step.CriteriaTree != null).Any(
                                        step =>
                                            step.CriteriaTree.Id == criteriaTreeId ||
                                            CriteriaTreeHasChildCriteriaTreeId(step.CriteriaTree, criteriaTreeId)))
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
                case ScenarioSearchType.ByCriteriaTreeDescription:
                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Steps.Where(step => step.CriteriaTree != null).Any(
                                        step =>
                                            step.CriteriaTree.Description.ToLower().Contains(textBoxSearchScenarios.Text.ToLower()) ||
                                            CriteriaTreeHasChildCriteriaTreeDescription(step.CriteriaTree, textBoxSearchScenarios.Text)))
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
                case ScenarioSearchType.UsesCriteriaId:
                    uint criteriaId;
                    if (!uint.TryParse(textBoxSearchScenarios.Text, out criteriaId))
                        break;

                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Steps.Where(step => step.CriteriaTree != null).Any(
                                        step =>
                                            step.CriteriaTree.CriteriaId == criteriaId ||
                                            CriteriaTreeHasChildCriteriaId(step.CriteriaTree, criteriaId)))
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
                case ScenarioSearchType.UsesCriteriaType:
                {
                    int criteriaTypeId;
                    if (!int.TryParse(textBoxSearchScenarios.Text, out criteriaTypeId))
                    {
                        listBoxScenarios.DataSource = SearchByCriteriaTypeDescription(textBoxSearchScenarios.Text);
                        break;
                    }

                    CriteriaType type = (CriteriaType) criteriaTypeId;
                    List<Scenario> scenarios = Scenarios.Where(scenario => scenario.Value.Steps.Where(step => step.CriteriaTree != null).Any(step => CriteriaTreeHasChildCriteriaType(step.CriteriaTree, type))).Select(scenario => scenario.Value).ToList();

                    if (!scenarios.Any())
                    {
                        listBoxScenarios.DataSource = SearchByCriteriaTypeDescription(textBoxSearchScenarios.Text);
                        break;
                    }

                    listBoxScenarios.DataSource = scenarios;
                    break;
                }
                case ScenarioSearchType.HasBonusObjective:
                    listBoxScenarios.DataSource =
                        Scenarios.Where(
                                scenario =>
                                    scenario.Value.Steps.Any(step => (step.Flags & ScenarioStepFlag.BonusObjective) != 0))
                            .Select(scenario => scenario.Value)
                            .ToList();
                    break;
            }
        }

        public bool CriteriaTreeHasChildCriteriaTreeId(CriteriaTree criteriaTree, uint criteriaTreeId)
        {
            return criteriaTree.Children.Any(child => child.Id == criteriaTreeId) ||
                   criteriaTree.Children.Any(child => CriteriaTreeHasChildCriteriaTreeId(child, criteriaTreeId));
        }

        public bool CriteriaTreeHasChildCriteriaTreeDescription(CriteriaTree criteriaTree, string description)
        {
            return criteriaTree.Children.Any(child => child.Description.ToLower().Contains(description)) ||
                   criteriaTree.Children.Any(child => CriteriaTreeHasChildCriteriaTreeDescription(child, description));
        }

        public bool CriteriaTreeHasChildCriteriaId(CriteriaTree criteriaTree, uint criteriaId)
        {
            return criteriaTree.Children.Any(child => child.CriteriaId == criteriaId) ||
                   criteriaTree.Children.Any(child => CriteriaTreeHasChildCriteriaId(child, criteriaId));
        }

        public bool CriteriaTreeHasChildCriteriaType(CriteriaTree criteriaTree, CriteriaType type)
        {
            return (criteriaTree.Criteria != null && criteriaTree.Criteria.Type == type) ||
                   criteriaTree.Children.Any(child => CriteriaTreeHasChildCriteriaType(child, type));
        }

        private List<Scenario> SearchByScenarioTypeDescription(string description)
        {
            Dictionary<ScenarioType, string> scenarioTypesWithDescriptions = new Dictionary<ScenarioType, string>();
            Enum.GetValues(typeof(ScenarioType))
                .Cast<ScenarioType>()
                .Select(type => new KeyValuePair<ScenarioType, string>(type, type.GetDescription()))
                .ToList()
                .ForEach(pair => scenarioTypesWithDescriptions.Add(pair.Key, pair.Value));

            List<ScenarioType> typesMatch =
                scenarioTypesWithDescriptions.Where(
                        typePair =>
                            typePair.Value.ToLower(CultureInfo.InvariantCulture)
                                .Contains(description.ToLower(CultureInfo.InvariantCulture)))
                    .Select(typePair => typePair.Key)
                    .ToList();
            return
                Scenarios.Where(scenario => typesMatch.Contains(scenario.Value.Type))
                    .Select(scenario => scenario.Value)
                    .ToList();
        }

        private List<Scenario> SearchByCriteriaTypeDescription(string description)
        {
            Dictionary<CriteriaType, string> criteriaTypesWithDescriptions = new Dictionary<CriteriaType, string>();
            Enum.GetValues(typeof(CriteriaType))
                .Cast<CriteriaType>()
                .Select(type => new KeyValuePair<CriteriaType, string>(type, type.GetDescription()))
                .ToList()
                .ForEach(pair => criteriaTypesWithDescriptions.Add(pair.Key, pair.Value));

            List<CriteriaType> typesMatch =
                criteriaTypesWithDescriptions.Where(
                        typePair =>
                            typePair.Value.ToLower(CultureInfo.InvariantCulture)
                                .Contains(description.ToLower(CultureInfo.InvariantCulture)))
                    .Select(typePair => typePair.Key)
                    .ToList();
            return
                Scenarios.Where(scenario => scenario.Value.Steps.Where(step => step.CriteriaTree != null).Any(step => CriteriaTreeHasCriteriaWithType(step.CriteriaTree, typesMatch))).Select(scenario => scenario.Value)
                    .ToList();
        }

        public bool CriteriaTreeHasCriteriaWithType(CriteriaTree tree, IEnumerable<CriteriaType> types)
        {
            return (tree.Criteria != null && types.Contains(tree.Criteria.Type)) ||
                   tree.Children.Any(child => CriteriaTreeHasCriteriaWithType(child, types));
        }

        private void textBoxSearchScenarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            buttonSearchScenarios.PerformClick();
        }

        private void scenarioSearchBy_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            if (comboBox == null)
                return;

            ScenarioSearchType type = (ScenarioSearchType) comboBox.SelectedItem;
            if (type == ScenarioSearchType.HasBonusObjective)
            {
                textBoxSearchScenarios.Enabled = false;
                buttonSearchScenarios.PerformClick();
            }
            else
                textBoxSearchScenarios.Enabled = true;
        }
        
        private void linkLabelScenarioStepQuestReward_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(WowheadUtils.GetWowheadURLForQuest(uint.Parse(textBoxScenarioStepQuestRewardId.Text)));
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
            
            UpdateDBCFiles();
            UpdateDBData();
        }

        public void UpdateDBCFiles()
        {
            if (ProgramSettings.UseDungeonEncounters && !_dbcDataStore.DungeonEncounters.Any())
                LoadDungeonEncounters();
            else if (!ProgramSettings.UseDungeonEncounters && _dbcDataStore.DungeonEncounters.Any())
                _dbcDataStore.DungeonEncounters.Clear();

            if (ProgramSettings.UseItems && !_dbcDataStore.Items.Any())
                LoadItems();
            else if (!ProgramSettings.UseItems && _dbcDataStore.Items.Any())
                _dbcDataStore.Items.Clear();

            if (ProgramSettings.UseSpells && !_dbcDataStore.Spells.Any())
                LoadSpells();
            else if (!ProgramSettings.UseSpells && _dbcDataStore.Spells.Any())
                _dbcDataStore.Spells.Clear();
        }

        public void UpdateDBData()
        {
            if (!ProgramSettings.UseCreatureNames && _dbDataStore.CreatureNames.Any())
                _dbDataStore.CreatureNames.Clear();
            else if (ProgramSettings.UseCreatureNames && !_dbDataStore.CreatureNames.Any())
                _dbDataStore.LoadCreatureNames();

            if (!ProgramSettings.UseGameobjectNames && _dbDataStore.GameobjectNames.Any())
                _dbDataStore.GameobjectNames.Clear();
            else if (ProgramSettings.UseGameobjectNames && !_dbDataStore.GameobjectNames.Any())
                _dbDataStore.LoadGameobjectNames();
        }

        private void treeViewScenarioStepCriteriaTrees_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!ProgramSettings.CriteriaTreeClickTriggersWowhead)
                return;

            TreeNode node = e.Node;
            if (node == null)
                return;

            Criteria criteria = node.Tag as Criteria;
            if (criteria == null)
                return;

            switch (criteria.Type)
            {
                case CriteriaType.KillCreature:
                    Process.Start(WowheadUtils.GetWowheadURLForCreature(criteria.Asset));
                    break;
                case CriteriaType.CastSpell:
                case CriteriaType.CastSpell2:
                case CriteriaType.BeSpellTarget:
                case CriteriaType.BeSpellTarget2:
                    Process.Start(WowheadUtils.GetWowheadURLForSpell(criteria.Asset));
                    break;
                case CriteriaType.LootItem:
                case CriteriaType.OwnItem:
                    Process.Start(WowheadUtils.GetWowheadURLForItem(criteria.Asset));
                    break;
                case CriteriaType.UseGameobject:
                case CriteriaType.SurveyGameobject:
                case CriteriaType.FishInGameobject:
                    Process.Start(WowheadUtils.GetWowheadURLForGameobject(criteria.Asset));
                    break;
                default:
                    break;
            }
        }
    }

    public enum ScenarioSearchType
    {
        [Description("Scenario name")]
        ByScenarioName,
        [Description("Scenario id")]
        ByScenarioId,
        [Description("Scenario type")]
        ByScenarioType,
        [Description("Step name")]
        ByScenarioStepName,
        [Description("Step id")]
        ByScenarioStepId,
        [Description("Step description")]
        ByScenarioStepDescription,
        [Description("Step uses criteria tree id")]
        UsesCriteriaTreeId,
        [Description("Scenario steps criteria trees description")]
        ByCriteriaTreeDescription,
        [Description("Step uses criteria id")]
        UsesCriteriaId,
        [Description("Step uses criteria type")]
        UsesCriteriaType,
        [Description("Has bonus objectives")]
        HasBonusObjective,
    }
}
