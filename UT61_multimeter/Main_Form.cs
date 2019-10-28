using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;



namespace UT61_multimeter
{
    public partial class Main_Form : Form
    {
        public static Main_Form main_f;

        public Main_Form()
        {
            InitializeComponent();
            main_f = this;
        }

        // moje klasy

        // sprawdzanie czy checkbox defoult jest True czy Flase
        private void Check_ChBox()
        {
            maskedTextBox1.Enabled = !checkBox1.Checked;
            maskedTextBox3.Enabled = !checkBox1.Checked;
            maskedTextBox2.Enabled = !checkBox1.Checked;
            numericUpDown1.Enabled = !checkBox1.Checked;
            checkBox2.Enabled = !checkBox1.Checked;
            checkBox3.Enabled = !checkBox1.Checked;

        }


        // auto klasy


        private void Main_Form_Load(object sender, EventArgs e)
        {
            Form loading = new Loading_Screen();
            loading.Show();

            Check_ChBox();
        }
                
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikacja obsługująca pomiary multimetru UT61.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settings_form = new RS_Settings();
            settings_form.Show();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename);
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Check_ChBox();
            serialPort.PortName = maskedTextBox1.Text; 
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Check_ChBox();
            serialPort.BaudRate = maskedTextBox3.Text;
            
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Check_ChBox();
            serialPort.Parity = maskedTextBox2.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Check_ChBox();
            serialPort.Parity =  numericUpDown1.Value;
        }

        // DTR settings checkbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Check_ChBox();
            serialPort.DtrEnable = checkBox2.Checked;
        }

        // RTS settings checkbox
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Check_ChBox();
            serialPort.RtsEnable = checkBox3.Checked;
        }

        // default settings checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Check_ChBox();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
