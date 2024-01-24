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
    public partial class UserHome : Form
    {
        OracleConnection con;
        public UserHome()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void UserHome_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Items ii = new Items();
            ii.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Must have Customer id Before you make Bill.");
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Establish a connection to the Oracle database
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            OracleConnection conn = new OracleConnection(conStr);
            conn.Open();
            // Retrieve the role of the user based on the username and password entered
            string role = "";
            string sql = $"SELECT Log_Rol FROM(SELECT Log_Rol FROM Login ORDER BY log_time DESC)WHERE ROWNUM = 1";
            OracleCommand command = new OracleCommand(sql, conn);
            OracleDataReader reader = command.ExecuteReader();
            // If a row is returned, the user is authenticated and we can retrieve their role
            if (reader.Read())
                role = reader.GetString(0);
            // Close the data reader and the connection
            reader.Close();
            conn.Close();
            // Check the role of the user and display the appropriate message
            if (role == "Super Admin")
            {
                Form2 SA = new Form2();
                SA.Show();
                this.Hide();
                //Back to Super Admin...
            }
            else
            {
                MessageBox.Show("You are not the Super Admin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuperAdminLogin button1 = new SuperAdminLogin();
            button1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCustomer obj = new AddCustomer();
            obj.Show();
            this.Hide();
        }
    }
}
