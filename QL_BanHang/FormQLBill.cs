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
    public partial class FormQLBill : Form
    {
        Bill bill = new Bill();
        public FormQLBill()
        {
            InitializeComponent();

            LoadFlpBill(DateTime.Now, DateTime.Now);           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FormAdmin form = new FormAdmin();
            form.ShowDialog();
            Close();
        }
        void LoadPnl2(Bill[] bills)
        {
            int amountBill = bills.Length;
            lbSLHoaDon.Text = amountBill.ToString();
            double avgBill_Info = 0;
            double avgTotalBill = 0;
            double sumDiscount = 0;
            foreach (Bill item in bills)
            {
                double total = item.Total;
                avgBill_Info += item.bill_Info.Length;
                avgTotalBill += total *(1-item.Discount);
                sumDiscount += total * item.Discount;
            }
            lbTongDoanhThu.Text = avgTotalBill.ToString() + " đ";
            lbHoanHuy.Text = (0).ToString() + " đ";
            lbTienHang.Text = (avgTotalBill + sumDiscount).ToString()+ " đ";
            lbGiamGia.Text = sumDiscount.ToString()+ " đ";
            lbTBHoaDon.Text = Math.Round((avgTotalBill/amountBill) , 0).ToString() + " đ";
            lbTBMatHang.Text = Math.Round((avgBill_Info/amountBill), 2).ToString()+ " đ";
            
        }
        void LoadFlpBill(DateTime FirstDay , DateTime SecondDay)
        {
            flpBill.Controls.Clear();
            Bill[] bills = Bill.FindBillDayBetweenDay(FirstDay,SecondDay);
            LoadPnl2(bills);
            foreach (Bill item in bills)
            {
                Button btn = new Button();
                btn.Text = $"{item.Id}\n\n{item.Total} Đ ";
                btn.Width = flpBill.Width/5 - 6;
                btn.Height = btn.Width*625/1000;
                btn.BackColor = Color.LightBlue;
                btn.Click += (object sender, EventArgs e) =>
                {
                    FormBill_Info form = new FormBill_Info(item);
                    form.ShowDialog();
                };

                flpBill.Controls.Add(btn);
            }
        }
        void LoadChart(DateTime day)
        {
            //chart1.Series["Series1"].Points.AddXY("Te5st", "3334");
        }
        private void FormQLBill_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime day = DateTime.Parse(mtbDay.Text);
                LoadFlpBill(day, day);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ , hãy chắc là bạn nhập đúng định dạng  yyyy / MM / dd");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Hide();
            FormMain form = new FormMain();
            form.ShowDialog();
            Close();
        }
    }
}
