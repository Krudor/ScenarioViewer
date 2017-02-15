namespace ScenarioViewer.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scenarios = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSearchScenarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxScenariosSearchBy = new System.Windows.Forms.ComboBox();
            this.buttonSearchScenarios = new System.Windows.Forms.Button();
            this.listBoxScenarios = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.treeViewScenarioStepCriteriaTrees = new System.Windows.Forms.TreeView();
            this.textBoxScenarioStepQuestRewardId = new System.Windows.Forms.TextBox();
            this.linkLabelScenarioStepQuestReward = new System.Windows.Forms.LinkLabel();
            this.textBoxScenarioStepDescription = new System.Windows.Forms.TextBox();
            this.labelScenarioStepDescription = new System.Windows.Forms.Label();
            this.listBoxScenarioSteps = new System.Windows.Forms.ListBox();
            this.checkBoxScenarioStepBonusObjective = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxScenarioStepRequiredStepId = new System.Windows.Forms.TextBox();
            this.labelScenarioStepRequiredStepId = new System.Windows.Forms.Label();
            this.textBoxScenarioStepId = new System.Windows.Forms.TextBox();
            this.textBoxScenarioStepIndex = new System.Windows.Forms.TextBox();
            this.labelScenarioStepIndex = new System.Windows.Forms.Label();
            this.labelScenarioStepId = new System.Windows.Forms.Label();
            this.labelScenarioStepName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxScenarioFlags = new System.Windows.Forms.ListBox();
            this.textBoxScenarioType = new System.Windows.Forms.TextBox();
            this.labelScenarioType = new System.Windows.Forms.Label();
            this.labelScenarioFlags = new System.Windows.Forms.Label();
            this.textBoxScenarioData = new System.Windows.Forms.TextBox();
            this.labelScenarioData = new System.Windows.Forms.Label();
            this.textBoxScenarioId = new System.Windows.Forms.TextBox();
            this.labelScenarioId = new System.Windows.Forms.Label();
            this.labelScenarioName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenarios.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scenarios
            // 
            this.scenarios.Controls.Add(this.tableLayoutPanel1);
            this.scenarios.Location = new System.Drawing.Point(4, 22);
            this.scenarios.Name = "scenarios";
            this.scenarios.Padding = new System.Windows.Forms.Padding(3);
            this.scenarios.Size = new System.Drawing.Size(1183, 526);
            this.scenarios.TabIndex = 1;
            this.scenarios.Text = "Scenarios";
            this.scenarios.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.36795F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.63205F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 520F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1177, 520);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBoxScenarios, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.98425F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.01575F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(191, 484);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxSearchScenarios);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxScenariosSearchBy);
            this.panel1.Controls.Add(this.buttonSearchScenarios);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 119);
            this.panel1.TabIndex = 1;
            // 
            // textBoxSearchScenarios
            // 
            this.textBoxSearchScenarios.Location = new System.Drawing.Point(7, 61);
            this.textBoxSearchScenarios.Name = "textBoxSearchScenarios";
            this.textBoxSearchScenarios.Size = new System.Drawing.Size(175, 20);
            this.textBoxSearchScenarios.TabIndex = 4;
            this.textBoxSearchScenarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchScenarios_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search for";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by";
            // 
            // comboBoxScenariosSearchBy
            // 
            this.comboBoxScenariosSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScenariosSearchBy.FormattingEnabled = true;
            this.comboBoxScenariosSearchBy.Location = new System.Drawing.Point(7, 20);
            this.comboBoxScenariosSearchBy.Name = "comboBoxScenariosSearchBy";
            this.comboBoxScenariosSearchBy.Size = new System.Drawing.Size(175, 21);
            this.comboBoxScenariosSearchBy.TabIndex = 1;
            this.comboBoxScenariosSearchBy.Tag = "Search by";
            this.comboBoxScenariosSearchBy.SelectedValueChanged += new System.EventHandler(this.scenarioSearchBy_SelectedValueChanged);
            // 
            // buttonSearchScenarios
            // 
            this.buttonSearchScenarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSearchScenarios.Location = new System.Drawing.Point(7, 88);
            this.buttonSearchScenarios.Name = "buttonSearchScenarios";
            this.buttonSearchScenarios.Size = new System.Drawing.Size(175, 23);
            this.buttonSearchScenarios.TabIndex = 0;
            this.buttonSearchScenarios.Text = "Search";
            this.buttonSearchScenarios.UseVisualStyleBackColor = true;
            this.buttonSearchScenarios.Click += new System.EventHandler(this.buttonSearchScenarios_Click);
            // 
            // listBoxScenarios
            // 
            this.listBoxScenarios.DisplayMember = "Display";
            this.listBoxScenarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxScenarios.FormattingEnabled = true;
            this.listBoxScenarios.Location = new System.Drawing.Point(3, 128);
            this.listBoxScenarios.Name = "listBoxScenarios";
            this.listBoxScenarios.Size = new System.Drawing.Size(185, 353);
            this.listBoxScenarios.TabIndex = 2;
            this.listBoxScenarios.ValueMember = "Value";
            this.listBoxScenarios.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.treeViewScenarioStepCriteriaTrees);
            this.panel2.Controls.Add(this.textBoxScenarioStepQuestRewardId);
            this.panel2.Controls.Add(this.linkLabelScenarioStepQuestReward);
            this.panel2.Controls.Add(this.textBoxScenarioStepDescription);
            this.panel2.Controls.Add(this.labelScenarioStepDescription);
            this.panel2.Controls.Add(this.listBoxScenarioSteps);
            this.panel2.Controls.Add(this.checkBoxScenarioStepBonusObjective);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxScenarioStepRequiredStepId);
            this.panel2.Controls.Add(this.labelScenarioStepRequiredStepId);
            this.panel2.Controls.Add(this.textBoxScenarioStepId);
            this.panel2.Controls.Add(this.textBoxScenarioStepIndex);
            this.panel2.Controls.Add(this.labelScenarioStepIndex);
            this.panel2.Controls.Add(this.labelScenarioStepId);
            this.panel2.Controls.Add(this.labelScenarioStepName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.listBoxScenarioFlags);
            this.panel2.Controls.Add(this.textBoxScenarioType);
            this.panel2.Controls.Add(this.labelScenarioType);
            this.panel2.Controls.Add(this.labelScenarioFlags);
            this.panel2.Controls.Add(this.textBoxScenarioData);
            this.panel2.Controls.Add(this.labelScenarioData);
            this.panel2.Controls.Add(this.textBoxScenarioId);
            this.panel2.Controls.Add(this.labelScenarioId);
            this.panel2.Controls.Add(this.labelScenarioName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(207, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 514);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(583, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Criterias";
            // 
            // treeViewScenarioStepCriteriaTrees
            // 
            this.treeViewScenarioStepCriteriaTrees.Location = new System.Drawing.Point(587, 43);
            this.treeViewScenarioStepCriteriaTrees.Name = "treeViewScenarioStepCriteriaTrees";
            this.treeViewScenarioStepCriteriaTrees.Size = new System.Drawing.Size(367, 444);
            this.treeViewScenarioStepCriteriaTrees.TabIndex = 33;
            this.treeViewScenarioStepCriteriaTrees.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewScenarioStepCriteriaTrees_NodeMouseDoubleClick);
            // 
            // textBoxScenarioStepQuestRewardId
            // 
            this.textBoxScenarioStepQuestRewardId.Location = new System.Drawing.Point(267, 144);
            this.textBoxScenarioStepQuestRewardId.Name = "textBoxScenarioStepQuestRewardId";
            this.textBoxScenarioStepQuestRewardId.ReadOnly = true;
            this.textBoxScenarioStepQuestRewardId.Size = new System.Drawing.Size(95, 20);
            this.textBoxScenarioStepQuestRewardId.TabIndex = 32;
            // 
            // linkLabelScenarioStepQuestReward
            // 
            this.linkLabelScenarioStepQuestReward.Location = new System.Drawing.Point(368, 143);
            this.linkLabelScenarioStepQuestReward.Name = "linkLabelScenarioStepQuestReward";
            this.linkLabelScenarioStepQuestReward.Size = new System.Drawing.Size(56, 20);
            this.linkLabelScenarioStepQuestReward.TabIndex = 31;
            this.linkLabelScenarioStepQuestReward.TabStop = true;
            this.linkLabelScenarioStepQuestReward.Text = "Wowhead";
            this.linkLabelScenarioStepQuestReward.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelScenarioStepQuestReward.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelScenarioStepQuestReward_LinkClicked);
            // 
            // textBoxScenarioStepDescription
            // 
            this.textBoxScenarioStepDescription.Location = new System.Drawing.Point(267, 183);
            this.textBoxScenarioStepDescription.Multiline = true;
            this.textBoxScenarioStepDescription.Name = "textBoxScenarioStepDescription";
            this.textBoxScenarioStepDescription.ReadOnly = true;
            this.textBoxScenarioStepDescription.Size = new System.Drawing.Size(307, 108);
            this.textBoxScenarioStepDescription.TabIndex = 29;
            // 
            // labelScenarioStepDescription
            // 
            this.labelScenarioStepDescription.AutoSize = true;
            this.labelScenarioStepDescription.Location = new System.Drawing.Point(265, 167);
            this.labelScenarioStepDescription.Name = "labelScenarioStepDescription";
            this.labelScenarioStepDescription.Size = new System.Drawing.Size(60, 13);
            this.labelScenarioStepDescription.TabIndex = 28;
            this.labelScenarioStepDescription.Tag = "";
            this.labelScenarioStepDescription.Text = "Description";
            // 
            // listBoxScenarioSteps
            // 
            this.listBoxScenarioSteps.DisplayMember = "Display";
            this.listBoxScenarioSteps.FormattingEnabled = true;
            this.listBoxScenarioSteps.Location = new System.Drawing.Point(28, 314);
            this.listBoxScenarioSteps.Name = "listBoxScenarioSteps";
            this.listBoxScenarioSteps.Size = new System.Drawing.Size(216, 173);
            this.listBoxScenarioSteps.TabIndex = 27;
            this.listBoxScenarioSteps.ValueMember = "Value";
            this.listBoxScenarioSteps.SelectedValueChanged += new System.EventHandler(this.listBoxScenarioSteps_SelectedValueChanged);
            // 
            // checkBoxScenarioStepBonusObjective
            // 
            this.checkBoxScenarioStepBonusObjective.Enabled = false;
            this.checkBoxScenarioStepBonusObjective.Location = new System.Drawing.Point(430, 102);
            this.checkBoxScenarioStepBonusObjective.Name = "checkBoxScenarioStepBonusObjective";
            this.checkBoxScenarioStepBonusObjective.Size = new System.Drawing.Size(132, 24);
            this.checkBoxScenarioStepBonusObjective.TabIndex = 26;
            this.checkBoxScenarioStepBonusObjective.Text = "Is bonus objective";
            this.checkBoxScenarioStepBonusObjective.UseVisualStyleBackColor = true;
            this.checkBoxScenarioStepBonusObjective.CheckedChanged += new System.EventHandler(this.checkBoxScenarioStepBonusObjective_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 24;
            this.label6.Tag = "";
            this.label6.Text = "Quest reward";
            // 
            // textBoxScenarioStepRequiredStepId
            // 
            this.textBoxScenarioStepRequiredStepId.Location = new System.Drawing.Point(430, 144);
            this.textBoxScenarioStepRequiredStepId.Name = "textBoxScenarioStepRequiredStepId";
            this.textBoxScenarioStepRequiredStepId.ReadOnly = true;
            this.textBoxScenarioStepRequiredStepId.Size = new System.Drawing.Size(133, 20);
            this.textBoxScenarioStepRequiredStepId.TabIndex = 23;
            this.textBoxScenarioStepRequiredStepId.Visible = false;
            // 
            // labelScenarioStepRequiredStepId
            // 
            this.labelScenarioStepRequiredStepId.AutoSize = true;
            this.labelScenarioStepRequiredStepId.Location = new System.Drawing.Point(427, 128);
            this.labelScenarioStepRequiredStepId.Name = "labelScenarioStepRequiredStepId";
            this.labelScenarioStepRequiredStepId.Size = new System.Drawing.Size(84, 13);
            this.labelScenarioStepRequiredStepId.TabIndex = 22;
            this.labelScenarioStepRequiredStepId.Tag = "";
            this.labelScenarioStepRequiredStepId.Text = "Required step id";
            this.labelScenarioStepRequiredStepId.Visible = false;
            // 
            // textBoxScenarioStepId
            // 
            this.textBoxScenarioStepId.Location = new System.Drawing.Point(267, 64);
            this.textBoxScenarioStepId.Name = "textBoxScenarioStepId";
            this.textBoxScenarioStepId.ReadOnly = true;
            this.textBoxScenarioStepId.Size = new System.Drawing.Size(50, 20);
            this.textBoxScenarioStepId.TabIndex = 21;
            // 
            // textBoxScenarioStepIndex
            // 
            this.textBoxScenarioStepIndex.Location = new System.Drawing.Point(267, 104);
            this.textBoxScenarioStepIndex.Name = "textBoxScenarioStepIndex";
            this.textBoxScenarioStepIndex.ReadOnly = true;
            this.textBoxScenarioStepIndex.Size = new System.Drawing.Size(157, 20);
            this.textBoxScenarioStepIndex.TabIndex = 20;
            // 
            // labelScenarioStepIndex
            // 
            this.labelScenarioStepIndex.AutoSize = true;
            this.labelScenarioStepIndex.Location = new System.Drawing.Point(264, 88);
            this.labelScenarioStepIndex.Name = "labelScenarioStepIndex";
            this.labelScenarioStepIndex.Size = new System.Drawing.Size(67, 13);
            this.labelScenarioStepIndex.TabIndex = 19;
            this.labelScenarioStepIndex.Tag = "";
            this.labelScenarioStepIndex.Text = "Step number";
            // 
            // labelScenarioStepId
            // 
            this.labelScenarioStepId.AutoSize = true;
            this.labelScenarioStepId.Location = new System.Drawing.Point(264, 48);
            this.labelScenarioStepId.Name = "labelScenarioStepId";
            this.labelScenarioStepId.Size = new System.Drawing.Size(16, 13);
            this.labelScenarioStepId.TabIndex = 16;
            this.labelScenarioStepId.Tag = "";
            this.labelScenarioStepId.Text = "Id";
            // 
            // labelScenarioStepName
            // 
            this.labelScenarioStepName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScenarioStepName.Location = new System.Drawing.Point(264, 10);
            this.labelScenarioStepName.Margin = new System.Windows.Forms.Padding(10);
            this.labelScenarioStepName.Name = "labelScenarioStepName";
            this.labelScenarioStepName.Size = new System.Drawing.Size(310, 20);
            this.labelScenarioStepName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Steps";
            // 
            // listBoxScenarioFlags
            // 
            this.listBoxScenarioFlags.FormattingEnabled = true;
            this.listBoxScenarioFlags.Location = new System.Drawing.Point(28, 183);
            this.listBoxScenarioFlags.Name = "listBoxScenarioFlags";
            this.listBoxScenarioFlags.Size = new System.Drawing.Size(216, 108);
            this.listBoxScenarioFlags.Sorted = true;
            this.listBoxScenarioFlags.TabIndex = 11;
            // 
            // textBoxScenarioType
            // 
            this.textBoxScenarioType.Location = new System.Drawing.Point(28, 104);
            this.textBoxScenarioType.Name = "textBoxScenarioType";
            this.textBoxScenarioType.ReadOnly = true;
            this.textBoxScenarioType.Size = new System.Drawing.Size(216, 20);
            this.textBoxScenarioType.TabIndex = 10;
            // 
            // labelScenarioType
            // 
            this.labelScenarioType.AutoSize = true;
            this.labelScenarioType.Location = new System.Drawing.Point(25, 87);
            this.labelScenarioType.Name = "labelScenarioType";
            this.labelScenarioType.Size = new System.Drawing.Size(31, 13);
            this.labelScenarioType.TabIndex = 9;
            this.labelScenarioType.Tag = "";
            this.labelScenarioType.Text = "Type";
            // 
            // labelScenarioFlags
            // 
            this.labelScenarioFlags.AutoSize = true;
            this.labelScenarioFlags.Location = new System.Drawing.Point(25, 167);
            this.labelScenarioFlags.Name = "labelScenarioFlags";
            this.labelScenarioFlags.Size = new System.Drawing.Size(32, 13);
            this.labelScenarioFlags.TabIndex = 7;
            this.labelScenarioFlags.Tag = "";
            this.labelScenarioFlags.Text = "Flags";
            // 
            // textBoxScenarioData
            // 
            this.textBoxScenarioData.Location = new System.Drawing.Point(28, 144);
            this.textBoxScenarioData.Name = "textBoxScenarioData";
            this.textBoxScenarioData.ReadOnly = true;
            this.textBoxScenarioData.Size = new System.Drawing.Size(216, 20);
            this.textBoxScenarioData.TabIndex = 6;
            // 
            // labelScenarioData
            // 
            this.labelScenarioData.AutoSize = true;
            this.labelScenarioData.Location = new System.Drawing.Point(25, 127);
            this.labelScenarioData.Name = "labelScenarioData";
            this.labelScenarioData.Size = new System.Drawing.Size(30, 13);
            this.labelScenarioData.TabIndex = 5;
            this.labelScenarioData.Tag = "";
            this.labelScenarioData.Text = "Data";
            // 
            // textBoxScenarioId
            // 
            this.textBoxScenarioId.Location = new System.Drawing.Point(28, 64);
            this.textBoxScenarioId.Name = "textBoxScenarioId";
            this.textBoxScenarioId.ReadOnly = true;
            this.textBoxScenarioId.Size = new System.Drawing.Size(50, 20);
            this.textBoxScenarioId.TabIndex = 4;
            // 
            // labelScenarioId
            // 
            this.labelScenarioId.AutoSize = true;
            this.labelScenarioId.Location = new System.Drawing.Point(25, 47);
            this.labelScenarioId.Name = "labelScenarioId";
            this.labelScenarioId.Size = new System.Drawing.Size(16, 13);
            this.labelScenarioId.TabIndex = 3;
            this.labelScenarioId.Tag = "";
            this.labelScenarioId.Text = "Id";
            // 
            // labelScenarioName
            // 
            this.labelScenarioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScenarioName.Location = new System.Drawing.Point(10, 10);
            this.labelScenarioName.Margin = new System.Windows.Forms.Padding(10);
            this.labelScenarioName.Name = "labelScenarioName";
            this.labelScenarioName.Size = new System.Drawing.Size(234, 20);
            this.labelScenarioName.TabIndex = 2;
            this.labelScenarioName.Text = "Scenario name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.scenarios);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1191, 552);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 576);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Scenario Viewer";
            this.scenarios.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage scenarios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSearchScenarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxScenariosSearchBy;
        private System.Windows.Forms.Button buttonSearchScenarios;
        private System.Windows.Forms.ListBox listBoxScenarios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeViewScenarioStepCriteriaTrees;
        private System.Windows.Forms.TextBox textBoxScenarioStepQuestRewardId;
        private System.Windows.Forms.LinkLabel linkLabelScenarioStepQuestReward;
        private System.Windows.Forms.TextBox textBoxScenarioStepDescription;
        private System.Windows.Forms.Label labelScenarioStepDescription;
        private System.Windows.Forms.ListBox listBoxScenarioSteps;
        private System.Windows.Forms.CheckBox checkBoxScenarioStepBonusObjective;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxScenarioStepRequiredStepId;
        private System.Windows.Forms.Label labelScenarioStepRequiredStepId;
        private System.Windows.Forms.TextBox textBoxScenarioStepId;
        private System.Windows.Forms.TextBox textBoxScenarioStepIndex;
        private System.Windows.Forms.Label labelScenarioStepIndex;
        private System.Windows.Forms.Label labelScenarioStepId;
        private System.Windows.Forms.Label labelScenarioStepName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxScenarioFlags;
        private System.Windows.Forms.TextBox textBoxScenarioType;
        private System.Windows.Forms.Label labelScenarioType;
        private System.Windows.Forms.Label labelScenarioFlags;
        private System.Windows.Forms.TextBox textBoxScenarioData;
        private System.Windows.Forms.Label labelScenarioData;
        private System.Windows.Forms.TextBox textBoxScenarioId;
        private System.Windows.Forms.Label labelScenarioId;
        private System.Windows.Forms.Label labelScenarioName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}