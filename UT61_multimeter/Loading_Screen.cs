﻿using System;
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
            Form main_f = new Main_Form();
            main_f.Hide();

            InitializeComponent();
        }

        private void Loading_Screen_Load(object sender, EventArgs e)
        {
            //Form main_f = new Main_Form();
            //main_f.Hide();


            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form main_f = new Main_Form();
            Form loading_s = new Loading_Screen();
            
            //main_f.Hide();

            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
            //    loading_s.Hide();
            //    main_f.Show();
            }
        }
    }
}
