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
            ingredient.Save();
        }

        private void FormIngredient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult dia = MessageBox.Show("Còn sản phẩm chưa lưu . bạn có muốn lưu không ?", "Lưu ?", MessageBoxButtons.OKCancel);
                if (dia == DialogResult.OK)
                {
                    ingredient.Save();
                }
            }
            catch (System.Data.SqlClient.SqlException) { return; }
            
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

        }
    }
}
