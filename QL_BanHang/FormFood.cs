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
    public partial class FormFood : Form
    {
        private double sec = 0.5;//Thời gian delay tìm kiếm food
        private List<Food> foodList = new List<Food>();
        public FormFood()
        {
            InitializeComponent();
            LoadCBBcate();
            LoadFood(Food.Find());
            
        }
        void LoadCBBcate()
        {
            string[] foodCategorys = Food.getCategory();
            foreach (string item in foodCategorys)
            {
                ccbLoaiMH.Items.Add(item);
            }
        }
        void LoadFood(Food[] foods)
        {
            flpFood.Controls.Clear();
            foreach (Food item in foods)
            {
                flpFood.Controls.Add(createFoodPanel(item));
            }
        }
        Panel createFoodPanel(Food food)
        {
            Panel createFoodPanel = new Panel();
            createFoodPanel.Font = new Font("Sans Serif", 10, FontStyle.Regular);
            createFoodPanel.AutoSize = true;

            Label lbName = new Label();
            lbName.AutoSize = true;
            lbName.Text = food.NameF;
            lbName.MaximumSize = new Size(100,40);
            lbName.Location = lbTenMH.Location;
            lbName.ForeColor = Color.Blue;

            Label lbCate = new Label();
            lbCate.Text = food.Category;
            lbCate.Location = lbLoaiMH.Location;

            Label lbPrice = new Label();
            lbPrice.Text = food.Price.ToString();
            lbPrice.Location = lbGia.Location;
            


            createFoodPanel.Controls.Add(lbName);
            createFoodPanel.Controls.Add(lbCate);
            createFoodPanel.Controls.Add(lbPrice);

            createFoodPanel.Click += (object sender, EventArgs e) =>
            {
                if(createFoodPanel.BackColor == Color.Aqua)
                {
                    createFoodPanel.BackColor = Color.White;
                    foodList.Remove(food);
                    createFoodPanel.Controls.RemoveAt(3);
                }
                else
                {
                    createFoodPanel.BackColor = Color.Aqua;
                    FlowLayoutPanel flpIngredient = createFLPIngredient(food.Ingredients);
                    flpIngredient.Location = new Point(0, createFoodPanel.Height + 2);
                    createFoodPanel.Controls.Add(flpIngredient);
                    foodList.Add(food);
                }
            };

            return createFoodPanel;
        }
        FlowLayoutPanel createFLPIngredient(Ingredient[] Ingredients)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Size = new Size(600,30);

            foreach (Ingredient item in Ingredients)
            {
                Panel panel = createPanelIngredient(item);
                flowLayoutPanel.Controls.Add(panel);
            }
             
           return flowLayoutPanel;
        }
        Panel createPanelIngredient(Ingredient ingredient)
        {
            Panel panel = new Panel();
            panel.Size = new Size(500, 20);

            Label lbName = new Label();
            lbName.Text = ingredient.Name;
            lbName.AutoSize = true;
            lbName.MaximumSize = new Size(150, 50);
            lbName.Location = new Point(77, 0);

            Label lbAmount = new Label();
            lbAmount.Text = ingredient.Amount.ToString();
            lbAmount.Location = new Point(280 , 0);

            
            panel.Controls.Add(lbAmount);
            panel.Controls.Add(lbName);

            return panel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSeach.Text = "";
            if(ccbLoaiMH.Text.Trim() == "All") { LoadFood(Food.Find()); }
            else { LoadFood(Food.FindWithCategory(ccbLoaiMH.Text)); }
        }

        private void tbSeach_TextChanged(object sender, EventArgs e)
        {
            
            if (tbSeach.Text == "")
            {
                lbSeach.Visible = true;
                iconClear.Visible = false;
            }
            else
            {
                lbSeach.Visible = false;
                iconClear.Visible = true;
            }
            timer1.Stop();
            sec = 0.5;
            timer1.Start();
        }

        private void tbSeach_Click(object sender, EventArgs e)
        {
            lbSeach.Visible = false;
        }

       

        private void iconClear_Click(object sender, EventArgs e)
        {
            tbSeach.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec -= 0.5;
            if (sec == 0)
            {
                LoadFood(Food.FindApproximateNameF(tbSeach.Text));
                timer1.Stop();
                sec = 0.5;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddFood form = new FormAddFood();
            form.ShowDialog();
            this.Close();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormUpdateFood2 form = new FormUpdateFood2(foodList);
            form.ShowDialog();
            this.Close();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormManagement form = new FormManagement();
            form.ShowDialog();
            this.Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Xóa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                int del = foodList.Count;
                foreach (Food item in foodList)
                {
                    item.Delete();
                }
                MessageBox.Show($"{del} mặt hàng được xóa");
            }
        }
    }
}
