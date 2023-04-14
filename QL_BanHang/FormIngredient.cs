using DocumentFormat.OpenXml.Drawing.Charts;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang
{
    public partial class FormIngredient : Form
    {
        private Food food = new Food();
        private Ingredient ingredient = new Ingredient();
        public FormIngredient(Food food)
        {
            InitializeComponent();
            this.food = food;
            
            LoadDgv(food.Ingredients);
        }
        void LoadDgv(Ingredient[] ingredients)
        {
            dataGridView1.DataSource = ingredients;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            ingredient.Amount = Convert.ToDouble(dataGridView1.Rows[index].Cells["Amount"].Value.ToString());
            ingredient.Name = dataGridView1.Rows[index].Cells["Name"].Value.ToString();
            ingredient.Inventory = ingredient.getInventory();
            ingredient.Save();
        }

        private void FormIngredient_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (ingredient == null) {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm");
            }
            else
            {
                ingredient.Delete();
                LoadDgv(food.Ingredients);
                MessageBox.Show("Xóa Thành Công");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                int index = e.RowIndex;
                string name = dataGridView1.Rows[index].Cells["Name"].Value.ToString();
                string nameF = dataGridView1.Rows[index].Cells["NameF"].Value.ToString();
                double amount = Convert.ToDouble(dataGridView1.Rows[index].Cells["Amount"].Value.ToString());
                double inv = Convert.ToDouble(dataGridView1.Rows[index].Cells["Inventory"].Value.ToString());
                ingredient = new Ingredient(name, nameF, amount, inv);
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            int lenght = food.Ingredients.Length;
            Ingredient[] ingredients = new Ingredient[lenght + 1];
            for (int i = 0; i < lenght; i++)
            {
                ingredients[i] = food.Ingredients[i];
            }
            ingredients[lenght] = new Ingredient("" , ingredients[0].NameF , 0 , 0);
            dataGridView1.DataSource = ingredients;
        }
    }
}
