﻿using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang
{
    public partial class FormUpdateFood : Form
    {
        public FormUpdateFood()
        {
            InitializeComponent();
            
        }
        public FormUpdateFood(Food[] foods)
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFood form = new FormFood();
            form.ShowDialog();
            this.Close();
        }
    }
}
