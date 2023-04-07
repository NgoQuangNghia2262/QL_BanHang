﻿using DTO;
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
        Bill bill = new Bill();
        public FormAdmin()
        {
            InitializeComponent();
            string s = mtbDay.Text;
            DateTime firstDay = DateTime.Parse(mtbDay.Text);
            Bill[] bills = bill.FindBillDayBetweenDay(firstDay, DateTime.Now);
            LoadTopFood();
            loadHeader(bills);
        }
        void loadHeader(Bill[] bills)
        {
            lbDonHang.Text = bills.Length.ToString();
            lbSLBan.Text = Table.Count(0).ToString();
            lbBanSD.Text = Table.Count(1).ToString();
            int trado = 0;
            double doanhthu = 0, giatritrado = 0;
            foreach (Bill item in bills)
            {
                if(item.Status == 1) { doanhthu += (item.Total * (1 - item.Discount)); }
                else if(item.Status == 2)
                {
                    trado += item.bill_Info.Length;
                    giatritrado += item.Total;
                }
            }
            lbTraDo.Text = trado.ToString();
            lbDoanhThu.Text = doanhthu.ToString();
            lbGiaTriTraDo.Text = giatritrado.ToString();

        }
        void LoadTopFood()
        {
            flpTopFood.Controls.Clear();
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
        private void button1_Click(object sender, EventArgs e)
        {
            LoadTopFood();
        }
    }
}
