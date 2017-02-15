using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioViewer.Forms
{
    public partial class DatabaseDetailsForm : Form
    {
        public DatabaseDetailsForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgramSettings.DBUsername = textBox1.Text;
            ProgramSettings.DBPassword = textBox2.Text;
            ProgramSettings.DBDatabase = textBox3.Text;
            ProgramSettings.DBServer = textBox4.Text;
            ProgramSettings.DBPort = textBox5.Text;
            Close();
        }

        private void DatabaseDetailsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = ProgramSettings.DBUsername;
            textBox2.Text = ProgramSettings.DBPassword;
            textBox3.Text = ProgramSettings.DBDatabase;
            textBox4.Text = ProgramSettings.DBServer;
            textBox5.Text = ProgramSettings.DBPort;
        }
    }
}
