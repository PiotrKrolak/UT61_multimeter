using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace UT61_multimeter
{
    
    public partial class Loading_Screen : Form
    {
        
        public Loading_Screen()
        {
           InitializeComponent();
        }

        private void Loading_Screen_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           Form loading_s = new Loading_Screen();

            Main_Form.main_f.Hide();
            // okodowanie progres bar
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                Main_Form.main_f.Show();
            }
        }
    }
}
