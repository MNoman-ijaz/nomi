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
    public partial class Items : Form
    {
        OracleConnection con;
        public Items()
        {
            InitializeComponent();
        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getUser = con.CreateCommand();
            getUser.CommandText = "SELECT * FROM Items";
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
                string ItemID = textBox1.Text;
                string ItemName = textBox3.Text;
                string ItemQuan = textBox2.Text;
                string ItemPrice = textBox6.Text;
                string ItemDesc = textBox4.Text;
                string ItemCategory = textBox5.Text;
                string pr_id = textBox7.Text;
                if (ItemID!=""&& ItemName!="" && ItemQuan != ""&& ItemPrice!=""&& ItemDesc!="" && ItemCategory!=""&&pr_id!="")
                {
                    con.Open();
                    OracleCommand insertUser = con.CreateCommand();
                    insertUser.CommandText = "INSERT INTO Items VALUES('" + ItemID + "','" + ItemName + "','" + ItemQuan + "','" + ItemPrice + "','" + ItemCategory + "','" + ItemDesc + "')";
                    insertUser.CommandType = CommandType.Text;
                    int rows = insertUser.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Data Successfully Inserted");
                    string email = "";
                    int amount = Convert.ToInt32(ItemPrice) * Convert.ToInt32(ItemQuan);
                    con.Close();
                    updateGrid();  
                    con.Open();
                    string sql1 = "BEGIN :result := get_recent_login_email(); END;";
                    OracleCommand command1 = new OracleCommand(sql1, con);
                    command1.Parameters.Add("result", OracleDbType.Varchar2, 30).Direction = ParameterDirection.ReturnValue;
                    command1.ExecuteNonQuery();
                    email = command1.Parameters["result"].Value.ToString();
                    con.Close();
                    con.Open();
                    string sql3 = $"INSERT INTO t2 (Purchase_ID, Supplier_ID, EMP_EMAIL, QUANTITY, ITEMID, Amount) VALUES ('{pr_id}', '{ItemCategory}', '{email}','{ItemQuan}','{ItemID}','{amount}')";
                    OracleCommand command3 = new OracleCommand(sql3, con);
                    command3.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Invaild Input.");
                }
                   
            }
            catch
            {
                MessageBox.Show("Invalid Input.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemID = textBox1.Text;
                string ItemName = textBox3.Text;
                string ItemQuan = textBox2.Text;
                string ItemPrice = textBox6.Text;
                string ItemDesc = textBox4.Text;
                string ItemCategory = textBox5.Text;
                con.Open();
                OracleCommand updateUser = con.CreateCommand();
                updateUser.CommandText = "UPDATE Items SET ItemName='" + ItemName + "', ItemQuantity='" + ItemQuan + "', ItemPrice = '" + ItemPrice + "', ItemDesc = '" + ItemDesc + "' WHERE  itemID  ='" + ItemID + "'";
                updateUser.CommandType = CommandType.Text;
                int rows = updateUser.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Successfully Updated");

                con.Close();
                updateGrid();
            }
            catch
            {
                MessageBox.Show("Invalid Input.");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            UserHome UH = new UserHome();
            UH.Show();
            this.Hide();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
            updateGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemID = textBox1.Text;
                con.Open();
                OracleCommand deleteUser = con.CreateCommand();
                deleteUser.CommandText = "DELETE FROM Items WHERE ItemID = '" + ItemID + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 obj = new Form4();
            obj.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
