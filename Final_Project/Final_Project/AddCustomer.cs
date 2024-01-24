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
    public partial class AddCustomer : Form
    {
        OracleConnection con;
        public AddCustomer()
        {
            InitializeComponent();
        }
        private void AddCustomer_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = textBox2.Text;
            string s2 = textBox3.Text;
            string s3 = textBox4.Text;

            if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2) && !string.IsNullOrEmpty(s3))
            {
                string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
                OracleConnection conn = new OracleConnection(conStr);

                try
                {
                    conn.Open();
                    string sql = $"INSERT INTO CUSTOMERS (CUSID, CUSNAME, CUSEMAIL) VALUES ('{s1}', '{s2}', '{s3}')";
                    OracleCommand command = new OracleCommand(sql, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Customer's Data Successfully Entered.");
                    textBox2.Text="";
                    textBox3.Text="";
                    textBox4.Text="";
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Please enter values for all fields.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserHome UH = new UserHome();
            UH.Show();
            this.Hide();
        }
    }
}
