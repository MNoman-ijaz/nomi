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

    public partial class Report : Form
    {
        OracleConnection conn;
        public Report()
        {
            InitializeComponent();
        }
        private void Report_Load(object sender, EventArgs e)
        {
            
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            conn = new OracleConnection(conStr);
            try
            {
                conn.Open();

                // Step 1: Retrieve data from the Sale table
                string sql = "SELECT s.* FROM Ahmed s JOIN(SELECT SALEID FROM Ahmed GROUP BY SALEID) sub ON s.SALEID = sub.SALEID";
                OracleCommand command = new OracleCommand(sql, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.SelectCommand = command;
                // Step 2: Create a DataTable to store the retrieved data
                DataTable dataTable = new DataTable();

                // Step 3: Bind the DataTable to each DataGridView control
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database connection or data retrieval process
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            try
            {
                conn.Open();

                // Step 1: Retrieve data from the Sale table
                string sql = "SELECT * FROM t2";
                OracleCommand command = new OracleCommand(sql, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.SelectCommand = command;
                // Step 2: Create a DataTable to store the retrieved data
                DataTable dataTable = new DataTable();

                // Step 3: Bind the DataTable to each DataGridView control
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database connection or data retrieval process
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            try
            {
                conn.Open();

                // Step 1: Retrieve data from the Sale table
                string sql = "SELECT * FROM Sale";
                OracleCommand command = new OracleCommand(sql, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.SelectCommand = command;
                // Step 2: Create a DataTable to store the retrieved data
                DataTable dataTable = new DataTable();

                // Step 3: Bind the DataTable to each DataGridView control
                adapter.Fill(dataTable);
                dataGridView3.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database connection or data retrieval process
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
