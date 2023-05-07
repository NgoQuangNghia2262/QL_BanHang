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
    public partial class FormBill_Info : Form
    {
        public FormBill_Info(Bill bill)
        {
            InitializeComponent();
            LoadFlpBillInfo(bill);
        }
        void LoadFlpBillInfo(Bill bill)
        {
            flpBill_Info.Width = Screen.PrimaryScreen.WorkingArea.Width * 4/10;
            flpBill_Info.Height = Screen.PrimaryScreen.WorkingArea.Height * 6 / 10;
            FormBill form = new FormBill();
            foreach (Bill_Info item in bill.bill_Info)
            {
                Panel pnl = form.CreateBillInfo(flpBill_Info , item);
                flpBill_Info.Controls.Add(pnl);
            }
        }
       
    }
}
