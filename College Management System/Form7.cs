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
    public partial class Form7 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbCommand cm;
        OleDbDataReader dr;
        public Form7()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                string sid;
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                con.Open();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Please fill all details");
                }
                else
                {
                    str = "INSERT INTO stuinfo (StudentID,name,fname,mname,blood,dob,contact,address,gender,category,course,email) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + comboBox3.SelectedItem + "','" + textBox8.Text + "')";
                    sid = "INSERT INTO slogin (StudentID) VALUES('" + textBox1.Text + "')";
                    cmd = new OleDbCommand(str, con);
                    cm = new OleDbCommand(sid, con);
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
                    MessageBox.Show("Please insert Student ID");
                }
                else
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM stuinfo where StudentID='" + textBox1.Text + "'";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox2.Text = dr.GetString(1);
                        textBox3.Text = dr.GetString(2);
                        textBox4.Text = dr.GetString(3);
                        textBox5.Text = dr.GetString(4);
                        dateTimePicker1.Value = (DateTime)dr.GetValue(5);
                        textBox6.Text = dr.GetString(6);
                        textBox7.Text = dr.GetString(7);
                        comboBox1.Text = dr.GetString(8);
                        comboBox2.Text = dr.GetString(9);
                        comboBox3.Text = dr.GetString(10);
                        textBox8.Text = dr.GetString(11);
                    }
                }
            }
            catch(Exception ex)
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
                    str = "UPDATE stuinfo SET " +
                    "StudentID ='" + textBox1.Text + "'," +
                    "name ='" + textBox2.Text + "'," +
                    "fname = '" + textBox3.Text + "'," +
                    "mname = '" + textBox4.Text + "'," +
                    "blood = '" + textBox5.Text + "'," +
                    "dob = '" + dateTimePicker1.Text + "'," +
                    "contact = '" + textBox6.Text + "'," +
                    "address = '" + textBox7.Text + "'," +
                    "gender = '" + comboBox1.SelectedItem + "'," +
                    "category = '" + comboBox2.SelectedItem + "'," +
                    "course = '" + comboBox3.SelectedItem + "'," +
                    "email = '" + textBox8.Text + "' where StudentID='" + textBox1.Text + "'";
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
                str = "DELETE FROM stuinfo where StudentID='" + textBox1.Text + "'";
                del = "DELETE FROM slogin where StudentID='" + textBox1.Text + "'";
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
                textBox8.Text = "";
                dateTimePicker1.ResetText();
                comboBox1.ResetText();
                comboBox2.ResetText();
                comboBox3.ResetText();
                con.Close();
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
                textBox8.Text = "";
                dateTimePicker1.ResetText();
                comboBox1.ResetText();
                comboBox2.ResetText();
                comboBox3.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/Projects/College Management System/College Management System/College Management System/login.mdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from course";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["course"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
