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
        public FormUpdateFood()
        {
            InitializeComponent();
            
        }
        public FormUpdateFood(Food[] foods)
        {
            InitializeComponent();
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
        void LoadFlpUpdateFood(Food[] foods)
        {
            for (int i = 0; i < foods.Length; i++)
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
            panel.Controls.Add(stt);

            Label name = new Label();
            name.Text = food.NameF;
            name.Location = lbName.Location;
            panel.Controls.Add(name);

            TextBox price = new TextBox();
            price.Text = food.Price.ToString();
            price.Location = lbPrice.Location;
            panel.Controls.Add(price);

            ccbCategory.Text = food.Category;
            ccbCategory.Location = lbCate.Location;
            panel.Controls.Add(ccbCategory);
            return panel;
        }
    }
}
