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
    public partial class FormUpdateFood2 : Form
    {
        public FormUpdateFood2(List<Food> foods)
        {
            InitializeComponent();
            this.foods = foods;
            LoadDgv(foods);
        }
        private List<Food> foods = new List<Food>();
        private int index = -1;
        void LoadDgv(List<Food> foods)
        {
            dataGridView1.DataSource = foods;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexrow = e.RowIndex;
            tbName.Text = dataGridView1.Rows[indexrow].Cells[0].Value.ToString();
            tbPrice.Text = dataGridView1.Rows[indexrow].Cells[2].Value.ToString();
            cbbLoai.Text = dataGridView1.Rows[indexrow].Cells[1].Value.ToString();
            index = indexrow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormIngredient form = new FormIngredient(Food.Find(tbName.Text));
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Food food = new Food(item.Cells[0].Value.ToString());
                food.Price = double.Parse(item.Cells[2].Value.ToString());
                food.Category = item.Cells[1].Value.ToString();
                food.Save();
            }
            MessageBox.Show("Successfully !!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFood form = new FormFood();
            form.ShowDialog();
            this.Close();
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
