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
    public partial class FormUpdateFood : Form
    {
        private readonly Food food = new Food();
        private ComboBox ccbCategory = new ComboBox();
        private List<Food> foods;
        public FormUpdateFood()
        {
            InitializeComponent();
            
        }
        public FormUpdateFood(List<Food> foods)
        {
            InitializeComponent();
            this.foods = foods;
            ccbCategory = getCbbFoodCategory(food.getCategory());
            LoadFlpUpdateFood(foods);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFood form = new FormFood();
            form.ShowDialog();
            this.Close();
        }
        void LoadFlpUpdateFood(List<Food> foods)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                flpUpdateFood.Controls.Add(createPnlUpdateFood(foods[i] , i +1));
            }
        } 
        ComboBox getCbbFoodCategory(string[] categorys)
        {
            ComboBox cbbCategory = new ComboBox();
            foreach (string category in categorys)
            {
                cbbCategory.Items.Add(category);
            }
            return cbbCategory;
        }
        Panel createPnlUpdateFood(Food food , int STT)
        {
           
            Panel panel = new Panel();
            panel.Width = flpUpdateFood.Width;
            panel.Height = flpUpdateFood.Height;
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label stt = new Label();
            stt.Text = STT.ToString();
            stt.Location = lbSTT.Location;
            stt.Size = new Size(10,10);
            panel.Controls.Add(stt);

            Label name = new Label();
            name.Text = food.NameF;
            name.Location = lbName.Location;
            name.AutoSize = true;
            panel.Controls.Add(name);

            TextBox price = new TextBox();
            price.Text = food.Price.ToString();
            price.Location = lbPrice.Location;
            price.Width = 50;
            price.KeyPress += (object sender, KeyPressEventArgs e) => {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            };
            price.TextChanged += (object sender, EventArgs e) => { 
                string priceText = price.Text == "" ? "0" : price.Text;
                food.Price = double.Parse(priceText);
            };
            
            panel.Controls.Add(price);

            ccbCategory.Text = food.Category;
            ccbCategory.Location = lbCate.Location;
            ccbCategory.Width = 100;
            ccbCategory.SelectedIndexChanged += (object sender, EventArgs e) => { 
                food.Category = ccbCategory.Text;
            };
            panel.Controls.Add(ccbCategory);

            Button btn = new Button();
            btn.Text = "Nguyên Liệu";
            btn.Location = lbNguyenLieu.Location;
            btn.Width = 95;
           // btn.Height = 30;
            btn.Click += (object sender, EventArgs e) =>
            {
                FormIngredient form = new FormIngredient(food);
                form.ShowDialog();
            };
            panel.Controls.Add(btn);
            return panel;
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFood form = new FormFood();
            form.ShowDialog();
            this.Close();
        }
      
        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Food item in foods)
                {
                    item.Save();
                }
            }
            catch(Exception err) { MessageBox.Show(err.Message); }
        }
    }
}
