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
    public partial class Inventory : Form
    {
        OracleConnection con;
        public Inventory()
        {

            InitializeComponent();
        }

        private void updateGrid()
        {

        }
        private void Inventory_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string item_id = textBox1.Text;
            con.Open();
            OracleCommand insertUser = con.CreateCommand();
            insertUser.CommandText = "Select * from Items where itemID  = '" + item_id + "')";
            insertUser.CommandType = CommandType.Text;
            insertUser.ExecuteNonQuery();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Home
            UserHome UH = new UserHome();
            UH.Show();
            this.Hide();
        }

     
        public string TextBoxValue
        {
            get { return textBox2.Text; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.Rows.Count;
            if (a < 2) 
            {
                MessageBox.Show("Plz Enter Any Product First.");
            }
            else if(textBox3.Text=="")
            {
                MessageBox.Show("Plz Enter the Unique Bill no.");
            }
            else if(textBox4.Text=="")
            {
                MessageBox.Show("Enter the Customer Id.");
            }
            else
            {
                //Payment Button
                for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
                {
                    string itemID = dataGridView1.Rows[x].Cells[0].Value.ToString();
                    int quantity = Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value);

                    string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
                    OracleConnection conn = new OracleConnection(conStr);

                    try
                    {
                        conn.Open();
                        string sql = $"UPDATE ITEMS SET itemQuantity = itemQuantity - {quantity} WHERE itemID = '{itemID}'";
                        OracleCommand command = new OracleCommand(sql, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Open();

                        string email = "";

                        string sql1 = "BEGIN :result := get_recent_login_email(); END;";
                        OracleCommand command1 = new OracleCommand(sql1, conn);
                        command1.Parameters.Add("result", OracleDbType.Varchar2, 30).Direction = ParameterDirection.ReturnValue;

                        command1.ExecuteNonQuery();
                        int value = Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value.ToString()) * Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value.ToString());
                        email = command1.Parameters["result"].Value.ToString();

                        conn.Close();
                        String id=textBox3.Text;
                        String C_id=textBox4.Text;
                        string q = Convert.ToString(quantity);
                        String iId=itemID;
                        conn.Open();
                        string sql3 = $"INSERT INTO Ahmed (SALEID, CUSTID, EMP_EMAIL, QUANTITY, ITEMID,Amount) VALUES ('{id}', '{C_id}', '{email}','{q}','{iId}','{value}')";
                        OracleCommand command3 = new OracleCommand(sql3, conn);
                        command3.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Sales Sucessfully Booked.");
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
                MessageBox.Show("Your Payment is Done.\n");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string item_id = textBox1.Text;
                // Enter Button
                con.Open();
                OracleCommand getUser = con.CreateCommand();
                getUser.CommandText = "SELECT itemID, itemName, itemQuantity, itemPrice FROM Items WHERE itemID = '" + item_id + "'";
                getUser.CommandType = CommandType.Text;
                OracleDataReader UserDR = getUser.ExecuteReader();

                bool flag = false;
                int sum = 0, a = dataGridView1.Rows.Count;
                if (a == 0)
                {
                    DataTable Users = new DataTable();

                    if (dataGridView1.DataSource != null)
                    {
                        Users = (DataTable)dataGridView1.DataSource; // Get the existing data from the grid
                    }
                    Users.Load(UserDR); // Load the new data into the DataTable

                    dataGridView1.DataSource = Users; // Set the updated DataTable as the data source of the grid
                    dataGridView1.Rows[0].Cells[2].Value = "1";
                    // Create a new column and assign a name to it
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.HeaderText = "Totall:";
                    column.Name = "columnName"; // Set the unique name for the column

                    // Add the column to the dataGridView1's Columns collection
                    dataGridView1.Columns.Add(column);
                    dataGridView1.Rows[0].Cells[4].Value = Convert.ToString(Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value.ToString()) * Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value.ToString()));
                    con.Close();
                }
                else
                {
                    // Modify the DataTable to set a fixed value of 1 for itemQuantity
                    for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
                    {
                        if (dataGridView1.Rows[x].Cells[0].Value.ToString() == item_id)
                        {
                            dataGridView1.Rows[x].Cells[2].Value = Convert.ToString(Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value.ToString()) + 1);

                            flag = true;
                            con.Close();
                        }
                    }
                    if (flag == false)
                    {
                        DataTable Users = new DataTable();

                        if (dataGridView1.DataSource != null)
                        {
                            Users = (DataTable)dataGridView1.DataSource; // Get the existing data from the grid
                        }
                        Users.Load(UserDR); // Load the new data into the DataTable

                        dataGridView1.DataSource = Users; // Set the updated DataTable as the data source of the grid
                        dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value = "1";

                        con.Close();
                    }
                }
                for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
                {
                    dataGridView1.Rows[x].Cells[4].Value = Convert.ToString(Convert.ToInt32(dataGridView1.Rows[x].Cells[3].Value.ToString()) * Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value.ToString()));
                    sum += Convert.ToInt32(dataGridView1.Rows[x].Cells[3].Value.ToString()) * Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value.ToString());
                    con.Close();
                }
                textBox2.Text = Convert.ToString(sum);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}







