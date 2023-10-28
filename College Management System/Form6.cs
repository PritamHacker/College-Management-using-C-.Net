using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 show = new Form7();
            show.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 show = new Form8();
            show.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 show = new Form1();
            show.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 show = new Form9();
            show.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 show = new Form5();
            show.Show();
            this.Close();
        }
    }
}
