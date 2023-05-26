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
    public partial class FormAdmin : Form
    {
        Bill bill = new Bill();
        public FormAdmin()
        {
            InitializeComponent();
            DateTime firstDay = DateTime.Parse(mtbDay.Text);
            LoadTopFood(firstDay, DateTime.Now);
            loadHeader(firstDay, DateTime.Now);
            LoadCharTable(firstDay , DateTime.Now);
        }
        void loadHeader(DateTime firstDay , DateTime secondDay)
        {
            try
            {
            Bill[] bills = Bill.FindBillDayBetweenDay(firstDay, secondDay);
            lbDonHang.Text = bills.Length.ToString();
            lbSLBan.Text = Table.Count.ToString();
            lbBanSD.Text = Table.CountWithStatus(1).ToString();
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
            catch (ArgumentOutOfRangeException err) { MessageBox.Show(err.Message); }

        }
        void LoadCharTable(DateTime firstDay, DateTime secondDay)
        {
            try
            {
                chartTable.Series["Doanh Thu"].Points.Clear();
                int between = 7;
                TimeSpan fourTeenDay = new TimeSpan(14, 0, 0, 0);
                if (secondDay - firstDay < fourTeenDay) { between = 1; }
                while (firstDay < secondDay)
                {
                    double turnover = bill.getTurnoverDayBetweenDay(firstDay, firstDay.AddDays(between));
                    chartTable.Series["Doanh Thu"].Points.AddXY(firstDay.Day, turnover);
                    firstDay = firstDay.AddDays(between);

                }
                firstDay = firstDay.AddDays(-between);
                double turnover2 = bill.getTurnoverDayBetweenDay(firstDay, DateTime.Now);
                chartTable.Series["Doanh Thu"].Points.AddXY(firstDay.Day, turnover2);
            }
            catch(ArgumentOutOfRangeException err) { MessageBox.Show(err.Message); }
        }
        void LoadTopFood(DateTime firstDay , DateTime secondDay)
        {
            try
            {
                flpTopFood.Controls.Clear();
                Bill_Info[] billinfos = Bill_Info.getTop5FoodDayBetweenDay(firstDay, secondDay);
                for (int i = 0; i < billinfos.Length; i++)
                {
                    flpTopFood.Controls.Add(createItemTopFood(billinfos[i]));
                }
            }
            catch (ArgumentOutOfRangeException err) { MessageBox.Show(err.Message); }
           
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
            DateTime firstDay = DateTime.Parse(mtbDay.Text.ToString());
            loadHeader(firstDay , DateTime.Now);
            LoadTopFood(firstDay , DateTime.Now);
            LoadCharTable(firstDay , DateTime.Now);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormManagement form = new FormManagement();
            form.ShowDialog();
            this.Close();
        }
    }
}
