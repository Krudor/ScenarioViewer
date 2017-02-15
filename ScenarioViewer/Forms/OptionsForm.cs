using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioViewer.Forms
{
    public partial class OptionsForm : Form
    {   
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.UseDungeonEncounters = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.UseItems = checkBox2.Checked;
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = ProgramSettings.UseDungeonEncounters;
            checkBox2.Checked = ProgramSettings.UseItems;
            checkBoxVerboseCriteriaTree.Checked = ProgramSettings.VerboseCriteriaTree;
            checkBoxUseCreatureNames.Checked = ProgramSettings.UseCreatureNames;
            checkBoxUseGameobjectNames.Checked = ProgramSettings.UseGameobjectNames;
            checkBoxUseSpells.Checked = ProgramSettings.UseSpells;
            checkBoxCriteriaTreeviewWowhead.Checked = ProgramSettings.CriteriaTreeClickTriggersWowhead;
        }

        private void checkBoxVerboseCriteriaTree_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.VerboseCriteriaTree = checkBoxVerboseCriteriaTree.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseDetailsForm databaseDetailsForm = new DatabaseDetailsForm();
            databaseDetailsForm.ShowDialog();
        }

        private void checkBoxUseCreatureNames_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.UseCreatureNames = checkBoxUseCreatureNames.Checked;
        }

        private void checkBoxGameobjectNames_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.UseGameobjectNames = checkBoxUseGameobjectNames.Checked;
        }

        private void checkBoxUseSpells_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.UseSpells = checkBoxUseSpells.Checked;
        }

        private void checkBoxCriteriaTreeviewWowhead_CheckedChanged(object sender, EventArgs e)
        {
            ProgramSettings.CriteriaTreeClickTriggersWowhead = checkBoxCriteriaTreeviewWowhead.Checked;
        }
    }
}
