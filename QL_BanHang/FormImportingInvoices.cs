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
    public partial class FormImportingInvoices : Form
    {
        public FormImportingInvoices()
        {
            InitializeComponent();
            loadDgvHDB();
        }
        void loadDgvHDB()
        {
            ImportingInvoices[] importingInvoices = ImportingInvoices.Find();
            foreach (ImportingInvoices item in importingInvoices)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 100;
                btn.Text = item.Id.ToString();
                btn.Click += (object sender, EventArgs e) =>
                {
                    panel1.Visible = true;
                    LoadThongTinBill(item.Id);
                };
            }
        }
        ImportingInvoices_Info getImportingInvoices_Info()
        {
            ImportingInvoices_Info result = new ImportingInvoices_Info();
            result.NameF = cbbName.Text;
            string amountIngre = tbSL.Text == "" ? "1": tbSL.Text;
            result.Amount = double.Parse(amountIngre);
            string price = tbSL.Text == "" ? "0" : tbPrice.Text;
            result.Price = double.Parse(price);
            result.IdBill = int.Parse(lbId.Text);
            return result;
        }
        void LoadThongTinBill(int id)
        {
            ImportingInvoices_Info[] list = ImportingInvoices_Info.Find(id);
            dataGridView1.DataSource = list;

        }
        void LoadFlpBill()
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getImportingInvoices_Info().Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
