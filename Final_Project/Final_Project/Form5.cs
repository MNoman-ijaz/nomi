﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    
    public partial class Form5 : Form
    {
        public Form5(string receivedValue)
        {
            InitializeComponent();
        }
        public string ReceivedValue { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Hello, World!";
            MessageBox.Show(message);
        }
    }
}
