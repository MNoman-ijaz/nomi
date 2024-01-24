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
    public partial class SuperAdminLogin : Form
    {
        OracleConnection con;
        public SuperAdminLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = Amanullah; PASSWORD = Amanullah";
            //con = new OracleConnection(conStr);
            PasswordText.PasswordChar = '*';
        }

        private void UserNameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void showpasswrdTextBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showpasswrdTextBox.Checked)
            {
                PasswordText.PasswordChar = '\0';
            }
            else
            {
                PasswordText.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserNameText.Text = "";
            PasswordText.Text = "";
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Retrieve the username and password entered by the user
            string username = UserNameText.Text;
            string password = PasswordText.Text;
            // Establish a connection to the Oracle database
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            OracleConnection conn = new OracleConnection(conStr);
            conn.Open();
            // Retrieve the role of the user based on the username and password entered
            string role = "";
            string sql = $"SELECT Role FROM Users WHERE Username='{username}' AND Password='{password}'";
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
                string conStr1 = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
                OracleConnection con1 = new OracleConnection(conStr1);
                con1.Open();
                OracleCommand insertUser = con1.CreateCommand();
                insertUser.CommandText = "INSERT INTO Login VALUES('" + username + "', 'Super Admin', CURRENT_TIMESTAMP)";
                insertUser.CommandType = CommandType.Text;
                insertUser.ExecuteNonQuery();
                con1.Close();

                // Display a message for superadmins
                MessageBox.Show("Welcome, Super Admin!");
                Form2 SA = new Form2();
                SA.Show();
                this.Hide();
            }
            else if (role == "User")
            {
                string conStr2 = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
                OracleConnection con2 = new OracleConnection(conStr2);
                con2.Open();
                OracleCommand insertUser = con2.CreateCommand();
                insertUser.CommandText = "INSERT INTO Login VALUES('" + username + "', 'User', CURRENT_TIMESTAMP)";
                insertUser.CommandType = CommandType.Text;
                insertUser.ExecuteNonQuery();
                con2.Close();


                // Display a message for regular users
                MessageBox.Show("Welcome, User!");
                UserHome UH = new UserHome();
                UH.Show();
                this.Hide();
            }
            else
                // Display an error message if the user is not found in the database
                MessageBox.Show("Invalid Input.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
