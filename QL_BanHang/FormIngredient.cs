using DTO;
using System;
using System.Windows.Forms;

namespace QL_BanHang
{
    public partial class FormIngredient : Form
    {
        private Food food = new Food();
        private Ingredient ingredient;
        private bool change = false;
        public FormIngredient(Food food)
        {
            InitializeComponent();
            this.food = food;
            LoadDgv(ingredients());
        }
        Ingredient[] ingredients()
        {
            try
            {
                return food.Ingredients;
            }
            catch (ArgumentNullException) { return new Ingredient[0]; }
        }
        void LoadDgv(Ingredient[] ingredients)
        {
            dataGridView1.DataSource = ingredients;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             change = true;
            int index = e.RowIndex;
            double amount = Convert.ToDouble(dataGridView1.Rows[index].Cells["Amount"].Value.ToString());
            string name = dataGridView1.Rows[index].Cells["Name"].Value.ToString();
            double inventory = Ingredient.getInventory(name);
            ingredient = new Ingredient(name , food.NameF , amount , inventory);
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
                LoadDgv(ingredients()); 
                MessageBox.Show("Xóa Thành Công");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (change) {
                ingredient.Save(); 
                change = false; 
            }
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
            ingredients[lenght] = new Ingredient("" , food.NameF , 0 , 0);
            dataGridView1.DataSource = ingredients;
        }
    }
}
