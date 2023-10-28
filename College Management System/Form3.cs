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
    public partial class Form3 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Form3()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 show = new Form1();
            show.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM tlogin where TeacherID='" + textBox1.Text + "' AND psw='" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Form10 show = new Form10(textBox1.Text);
                    show.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("TeacherID or password is incorrect");
                    textBox2.Text = "";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                con.Open();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * from tlogin where TeacherID ='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please Insert TeacherID and Password");
                }
                else if (dr.Read())
                {
                    str = "UPDATE tlogin SET psw='" + textBox2.Text + "' where TeacherID = '" + textBox1.Text + "'";
                    cmd = new OleDbCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Password Created Successfully");
                }
                else
                {
                    MessageBox.Show("You are not registerd");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
