namespace ScenarioViewer.Forms
{
    partial class OptionsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseSpells = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxVerboseCriteriaTree = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseGameobjectNames = new System.Windows.Forms.CheckBox();
            this.checkBoxUseCreatureNames = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxCriteriaTreeviewWowhead = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.checkBoxUseSpells);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optional DBC files";
            // 
            // checkBoxUseSpells
            // 
            this.checkBoxUseSpells.AutoSize = true;
            this.checkBoxUseSpells.Location = new System.Drawing.Point(13, 88);
            this.checkBoxUseSpells.Name = "checkBoxUseSpells";
            this.checkBoxUseSpells.Size = new System.Drawing.Size(70, 17);
            this.checkBoxUseSpells.TabIndex = 3;
            this.checkBoxUseSpells.Text = "Spell.db2";
            this.checkBoxUseSpells.UseVisualStyleBackColor = true;
            this.checkBoxUseSpells.CheckedChanged += new System.EventHandler(this.checkBoxUseSpells_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 56);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(101, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Item-sparse.db2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 26);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "DungeonEncounter.db2";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxVerboseCriteriaTree
            // 
            this.checkBoxVerboseCriteriaTree.AutoSize = true;
            this.checkBoxVerboseCriteriaTree.Location = new System.Drawing.Point(13, 26);
            this.checkBoxVerboseCriteriaTree.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxVerboseCriteriaTree.Name = "checkBoxVerboseCriteriaTree";
            this.checkBoxVerboseCriteriaTree.Size = new System.Drawing.Size(125, 17);
            this.checkBoxVerboseCriteriaTree.TabIndex = 3;
            this.checkBoxVerboseCriteriaTree.Text = "Verbose Criteria Tree";
            this.checkBoxVerboseCriteriaTree.UseVisualStyleBackColor = true;
            this.checkBoxVerboseCriteriaTree.CheckedChanged += new System.EventHandler(this.checkBoxVerboseCriteriaTree_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.checkBoxCriteriaTreeviewWowhead);
            this.groupBox2.Controls.Add(this.checkBoxVerboseCriteriaTree);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Misc";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.checkBoxUseGameobjectNames);
            this.groupBox3.Controls.Add(this.checkBoxUseCreatureNames);
            this.groupBox3.Location = new System.Drawing.Point(184, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 213);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database data";
            // 
            // checkBoxUseGameobjectNames
            // 
            this.checkBoxUseGameobjectNames.AutoSize = true;
            this.checkBoxUseGameobjectNames.Location = new System.Drawing.Point(13, 49);
            this.checkBoxUseGameobjectNames.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxUseGameobjectNames.Name = "checkBoxUseGameobjectNames";
            this.checkBoxUseGameobjectNames.Size = new System.Drawing.Size(117, 17);
            this.checkBoxUseGameobjectNames.TabIndex = 7;
            this.checkBoxUseGameobjectNames.Text = "Gameobject names";
            this.checkBoxUseGameobjectNames.UseVisualStyleBackColor = true;
            this.checkBoxUseGameobjectNames.CheckedChanged += new System.EventHandler(this.checkBoxGameobjectNames_CheckedChanged);
            // 
            // checkBoxUseCreatureNames
            // 
            this.checkBoxUseCreatureNames.AutoSize = true;
            this.checkBoxUseCreatureNames.Location = new System.Drawing.Point(13, 26);
            this.checkBoxUseCreatureNames.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxUseCreatureNames.Name = "checkBoxUseCreatureNames";
            this.checkBoxUseCreatureNames.Size = new System.Drawing.Size(100, 17);
            this.checkBoxUseCreatureNames.TabIndex = 6;
            this.checkBoxUseCreatureNames.Text = "Creature names";
            this.checkBoxUseCreatureNames.UseVisualStyleBackColor = true;
            this.checkBoxUseCreatureNames.CheckedChanged += new System.EventHandler(this.checkBoxUseCreatureNames_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Database Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxCriteriaTreeviewWowhead
            // 
            this.checkBoxCriteriaTreeviewWowhead.Location = new System.Drawing.Point(13, 60);
            this.checkBoxCriteriaTreeviewWowhead.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxCriteriaTreeviewWowhead.Name = "checkBoxCriteriaTreeviewWowhead";
            this.checkBoxCriteriaTreeviewWowhead.Size = new System.Drawing.Size(125, 56);
            this.checkBoxCriteriaTreeviewWowhead.TabIndex = 4;
            this.checkBoxCriteriaTreeviewWowhead.Text = "Criteria treeview double-click opens wowhead";
            this.checkBoxCriteriaTreeviewWowhead.UseVisualStyleBackColor = true;
            this.checkBoxCriteriaTreeviewWowhead.CheckedChanged += new System.EventHandler(this.checkBoxCriteriaTreeviewWowhead_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 284);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxVerboseCriteriaTree;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxUseCreatureNames;
        private System.Windows.Forms.CheckBox checkBoxUseGameobjectNames;
        private System.Windows.Forms.CheckBox checkBoxUseSpells;
        private System.Windows.Forms.CheckBox checkBoxCriteriaTreeviewWowhead;
    }
}