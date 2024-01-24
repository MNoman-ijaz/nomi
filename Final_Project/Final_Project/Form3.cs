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
    public partial class ManageUsers : Form
    {
        OracleConnection con;
        public ManageUsers()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Add_User_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
            updateGrid();
        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getUser = con.CreateCommand();
            getUser.CommandText = "SELECT * FROM Users";
            getUser.CommandType = CommandType.Text;
            OracleDataReader UserDR = getUser.ExecuteReader();
            DataTable Users = new DataTable();
            Users.Load(UserDR);
            dataGridView1.DataSource = Users;

            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox3.Text;
                string email = textBox2.Text;
                con.Open();
                OracleCommand insertUser = con.CreateCommand();
                insertUser.CommandText = "INSERT INTO Users VALUES('" + username + "','" + password + "','" + email + "','" + "User" + "')";
                insertUser.CommandType = CommandType.Text;
                int rows = insertUser.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Successfully Inserted");

                con.Close();
                updateGrid();
            }
            catch {
                MessageBox.Show("Invalid Username OR Password OR Email");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //manage user
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox3.Text;
                string email = textBox2.Text;
                con.Open();
                OracleCommand deleteUser = con.CreateCommand();
                deleteUser.CommandText = "DELETE FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "' AND Email = '" + email + "' AND Role = 'User'";
                deleteUser.CommandType = CommandType.Text;
                int rows = deleteUser.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Successfully Deleted");

                con.Close();
                updateGrid();
            }
            catch
            {
                MessageBox.Show("Invalid Username OR Password OR Email");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox3.Text;
                string email = textBox2.Text;
                con.Open();
                OracleCommand updateUser = con.CreateCommand();
                updateUser.CommandText = "UPDATE Users SET Email='" + email + "', Password='" + password + "' WHERE Username='" + username + "'";
                updateUser.CommandType = CommandType.Text;
                int rows = updateUser.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Successfully Updated");

                con.Close();
                updateGrid();
            }
            catch
            {
                MessageBox.Show("Invalid Username OR Password OR Email");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SuperAdminLogin AL = new SuperAdminLogin();
            AL.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Home = new Form2();
            Home.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Username"].Value.ToString();
                textBox3.Text = row.Cells["Password"].Value.ToString();
                textBox2.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
