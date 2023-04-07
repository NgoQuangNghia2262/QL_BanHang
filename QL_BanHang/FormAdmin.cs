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
using System.Windows.Forms.DataVisualization.Charting;

namespace QL_BanHang
{
    public partial class FormAdmin : Form
    {
        Bill_Info bif = new Bill_Info();
        public FormAdmin()
        {
            InitializeComponent();
            LoadTopFood();
        }
        void LoadTopFood()
        {
            DateTime firstDay = DateTime.Parse(mtbDay.Text);
            Bill_Info[] billinfos = bif.getTop5FoodDayBetweenDay(firstDay, DateTime.Now);
            for (int i = 0; i < billinfos.Length; i++)
            {
                flpTopFood.Controls.Add(createItemTopFood(billinfos[i]));
            }
        }
         Panel createItemTopFood(Bill_Info bi)
        {
            Panel panel = new Panel();
            panel.Size = new Size(flpTopFood.Width*85/100 - 6, flpTopFood.Height / 5 - 6);
            //Tạo gạch dưới
            Panel br = new Panel();
            br.Size = new Size(panel.Width , 1);
            br.Location = new Point(0, panel.Height-2);
            br.BackColor = Color.Chocolate;

            //Tạo Tên Food , Microsoft Sans Serif, 10.2pt
            Label lbNameF = new Label();
            lbNameF.Text = bi.NameF;
            lbNameF.Font = new System.Drawing.Font("Sans Serif", 10, FontStyle.Bold);
            lbNameF.Location = new Point(10, panel.Height / 2 - 2);
            lbNameF.ForeColor = Color.Black;

            //Tạo số lượng
            Label lbAmount = new Label();
            lbAmount.Text = bi.Amount.ToString();
            lbAmount.Font = new System.Drawing.Font("Bold", 10, FontStyle.Bold);
            lbAmount.Location = new Point(panel.Width - 40 , panel.Height / 2 - 10);
            lbAmount.Size = new Size(30,30);
            lbAmount.TextAlign = ContentAlignment.MiddleCenter;
            lbAmount.BackColor = Color.Red;
            lbAmount.ForeColor = Color.White; 

            panel.Controls.Add(lbNameF);
            panel.Controls.Add(lbAmount);
            panel.Controls.Add(br);
            return panel;
        }

        private void dtpTopFood_ValueChanged(object sender, EventArgs e)
        {
            LoadTopFood();
        }
    }
}
