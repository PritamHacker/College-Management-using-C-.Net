using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class Form10 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Form10(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM teacherinfo where TeacherID = '" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr.GetString(1);
                    textBox3.Text = dr.GetString(2);
                    textBox4.Text = dr.GetDateTime(3).ToString("dd-MM-yyyy");
                    textBox5.Text = dr.GetString(6);
                    textBox6.Text = dr.GetString(7);
                    textBox7.Text = dr.GetString(8);
                    textBox8.Text = dr.GetString(5);
                    textBox9.Text = dr.GetString(4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 show = new Form1();
            show.Show();
            this.Close();
        }
    }
}
