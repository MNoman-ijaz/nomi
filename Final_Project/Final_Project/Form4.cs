using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Final_Project
{
    public partial class Form4 : Form
    {
        OracleConnection con;
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items obj=new Items();
            obj.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sID = textBox1.Text;
                string sName = textBox3.Text;
                string sEmail = textBox2.Text;
                con.Open();
                if(sID!=""&& sName!=""&& sEmail!="")
                {
                    OracleCommand insertUser = con.CreateCommand();
                    insertUser.CommandText = "INSERT INTO Suppliers VALUES('" + sID + "','" + sName + "','" + sEmail + "',NULL,NULL)";
                    insertUser.CommandType = CommandType.Text;
                    int rows = insertUser.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Data Successfully Inserted");

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Input:");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input.");
            }
            Items obj = new Items();
            obj.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
        }
    }
}
