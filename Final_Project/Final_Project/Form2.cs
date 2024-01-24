using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using Oracle.ManagedDataAccess.Client;

namespace Final_Project
{
    public partial class Form2 : Form
    {
        OracleConnection con;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuperAdminLogin button3 = new SuperAdminLogin();
            button3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; USER ID = 21F-9517; PASSWORD = 21F-9517";
            con = new OracleConnection(conStr);
            updateGrid1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
            this.Hide();
        }
        private void updateGrid1()
        {
            con.Open();
            OracleCommand getitem = con.CreateCommand();
            getitem.CommandText = "SELECT * from Items";
            getitem.CommandType = CommandType.Text;
            OracleDataReader itemDR = getitem.ExecuteReader();
            DataTable items = new DataTable();
            items.Load(itemDR);
            dataGridView1.DataSource = items;
            con.Close();
        }
       
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserHome UH = new UserHome();
            UH.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report obj = new Report();
            obj.Show();
            this.Hide();
        }
    }
}
