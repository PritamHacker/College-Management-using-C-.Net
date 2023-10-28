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
    public partial class Form9 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
       // OleDbCommand cm;
        OleDbDataReader dr;
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=                ");
                con.Open();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Please fill all details");
                }
                else
                {
                    str = "INSERT INTO course (code,course,title,fee,duration) VALUES(" + textBox1.Text + ",'" + textBox2.Text + "','" + comboBox1.SelectedItem + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    cmd = new OleDbCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Insert Successfully");
                    con.Close();
                }
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
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please insert Course/Subject Code");
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM course where code=" + textBox1.Text + "";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox2.Text = dr.GetString(1);
                        comboBox1.Text = dr.GetString(2);
                        textBox3.Text = dr.GetString(3);
                        textBox4.Text = dr.GetString(4);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                con.Open();
                str = "UPDATE course SET " +
                "course ='" + textBox2.Text + "'," +
                "title = '" + comboBox1.SelectedItem + "'," +
                "fee = '" + textBox3.Text + "'," +
                "duration = '" + textBox4.Text + "' where code=" + textBox1.Text + "";
                cmd = new OleDbCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record UPDATED Successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
             //   string del;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                con.Open();
                str = "DELETE FROM course where code=" + textBox1.Text + "";
               // del = "DELETE FROM slogin where StudentID='" + textBox1.Text + "'";
                cmd = new OleDbCommand(str, con);
               // cm = new OleDbCommand(del, con);
                cmd.ExecuteNonQuery();
             //   cm.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.ResetText();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 show = new Form6();
            show.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
