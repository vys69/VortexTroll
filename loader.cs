using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tool
{
    public partial class loader : Form
    {
        public loader()
        {
            InitializeComponent();
        }

        public loader(Form parentForm)
        {
            InitializeComponent();
            Form opener;
            opener = parentForm;
        }
        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void loader_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.guna2ProgressBar1.Increment(10);
            if(guna2ProgressBar1.Value >= guna2ProgressBar1.Maximum)
             {
            this.Close();
            Form2 frm = new Form2(this);
            frm.Show();
            }
        }


    }
}
