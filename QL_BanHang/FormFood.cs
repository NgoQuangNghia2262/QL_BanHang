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
        public FormFood()
        {
            InitializeComponent();
            Food food = new Food();
            flpFood.Controls.Add(createFoodPanel(food.Find("Gà Sốt Tiêu Xanh")));
        }
        void LoadFood(Food[] foods)
        {

        }
        Panel createFoodPanel(Food food)
        {
            Panel createFoodPanel = new Panel();
            createFoodPanel.AutoSize = true;

            Label lbName = new Label();
            lbName.Text = food.NameF;
            lbName.Location = lbTenMH.Location;
            lbName.Font = new Font("Sans Serif", 10, FontStyle.Regular);
            lbName.ForeColor = Color.Blue;

            Label lbCate = new Label();
            lbCate.Text = food.Category;
            lbCate.Location = lbLoaiMH.Location;
            lbCate.Font = new Font("Sans Serif", 10, FontStyle.Regular);

            Label lbPrice = new Label();
            lbPrice.Text = food.Price.ToString();
            lbPrice.Location = lbGia.Location;
            
            lbPrice.Font = new Font("Sans Serif", 10, FontStyle.Regular);


            createFoodPanel.Controls.Add(lbName);
            createFoodPanel.Controls.Add(lbCate);
            createFoodPanel.Controls.Add(lbPrice);

            createFoodPanel.Click += (object sender, EventArgs e) =>
            {
                if(createFoodPanel.BackColor == Color.Aqua)
                {
                    createFoodPanel.BackColor = Color.White;
                    createFoodPanel.Controls.RemoveAt(3);
                }
                else
                {
                    createFoodPanel.BackColor = Color.Aqua;
                    FlowLayoutPanel flpIngredient = createFLPIngredient(food.Ingredients);
                    flpIngredient.Location = new Point(0, createFoodPanel.Height + 2);
                    createFoodPanel.Controls.Add(flpIngredient);
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
            lbName.Location = new Point(77, 0);

            Label lbAmount = new Label();
            lbAmount.Text = ingredient.Amount.ToString();
            lbAmount.Location = new Point(140 , 0);

            
            panel.Controls.Add(lbAmount);
            panel.Controls.Add(lbName);

            return panel;
        }

    }
}
