using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QL_BanHang
{
    public partial class FormChuyenBan : Form
    {
        public FormChuyenBan(Bill bill)
        {
            InitializeComponent();
            LoadTable(bill);
        }
        void LoadTable(Bill bill)
        {
            Table[] tables = Table.Find();
            foreach (Table item in tables)
            {
                Button btn = new Button();
                btn.Text = item.Id.ToString();
                btn.Width = flpTable.Width / 4 - 12;
                btn.Height = Convert.ToInt32(btn.Width * 0.625);
                if (item.Status == 1) { btn.BackColor = Color.Aqua; }
                btn.Click += (object sender, EventArgs e) =>
                {
                    DialogResult dia = MessageBox.Show("Bạn có muốn gộp không", "Gộp ?", MessageBoxButtons.OKCancel);
                    if (dia != DialogResult.OK)
                    {
                        return;
                    }
                    Bill.MergeBill(bill, item.bill);
                    item.Status = 1;
                    item.Save();
                    Table tb = Table.Find(bill.IdTb);
                    tb.Status = 0;
                    tb.Save();
                    this.Hide();
                    FormMain form = new FormMain();
                    form.ShowDialog();
                    this.Close();
                };
                flpTable.Controls.Add(btn);
            }
        }
    }
}
