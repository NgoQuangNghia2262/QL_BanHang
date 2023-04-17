using DTO;
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
    public partial class FormAddFood : Form
    {
        private Food food = new Food();
        public FormAddFood()
        {
            InitializeComponent();
            LoadCbbCate();
        }
        void LoadCbbCate()
        {
            string[] cates = food.getCategory();
            foreach (string item in cates)
            {
                cbbCate.Items.Add(item);
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
                this.Hide();
                string price = tbPrice.Text == "" ? "0" : tbPrice.Text;
                food = new Food(tbName.Text, double.Parse(price), cbbCate.Text);
                food.Save();
                FormIngredient form = new FormIngredient(food);
                this.Close();
          
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFood form = new FormFood();
            form.ShowDialog();
            this.Close();
        }
    }
}
