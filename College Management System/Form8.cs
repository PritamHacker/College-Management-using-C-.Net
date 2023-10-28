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
    public partial class Form8 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbCommand cm;
        OleDbDataReader dr;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                string tid;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                con.Open();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("Please fill all details");
                }
                else
                {
                    str = "INSERT INTO teacherinfo (TeacherID,name,gender,dob,address,email,salary,subject,contact) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                    tid = "INSERT INTO tlogin (TeacherID) VALUES('" + textBox1.Text + "')";
                    cmd = new OleDbCommand(str, con);
                    cm = new OleDbCommand(tid, con);
                    cmd.ExecuteNonQuery();
                    cm.ExecuteNonQuery();
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
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please insert TeacherID");
                }
                else
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM teacherinfo where TeacherID='" + textBox1.Text + "'";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox2.Text = dr.GetString(1);
                        comboBox1.Text = dr.GetString(2);
                        dateTimePicker1.Value = (DateTime)dr.GetValue(3);
                        textBox3.Text = dr.GetString(4);
                        textBox4.Text = dr.GetString(5);
                        textBox5.Text = dr.GetString(6);
                        textBox6.Text = dr.GetString(7);
                        textBox7.Text = dr.GetString(8);

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
                str = "UPDATE teacherinfo SET " +
                "TeacherID ='" + textBox1.Text + "'," +
                "name ='" + textBox2.Text + "'," +
                "gender = '" + comboBox1.SelectedItem + "'," +
                "dob = '" + dateTimePicker1.Text + "'," +
                "address = '" + textBox3.Text + "'," +
                "email = '" + textBox4.Text + "'," +
                "salary = '" + textBox5.Text + "'," +
                "subject = '" + textBox6.Text + "'," +
                "contact = '" + textBox7.Text + "' where TeacherID='" + textBox1.Text + "'";
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
                string del;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                con.Open();
                str = "DELETE FROM teacherinfo where TeacherID='" + textBox1.Text + "'";
                del = "DELETE FROM tlogin where TeacherID='" + textBox1.Text + "'";
                cmd = new OleDbCommand(str, con);
                cm = new OleDbCommand(del, con);
                cmd.ExecuteNonQuery();
                cm.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.ResetText();
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
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.ResetText();
                comboBox1.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 show = new Form6();
            show.Show();
            this.Close();
        }
    }
}