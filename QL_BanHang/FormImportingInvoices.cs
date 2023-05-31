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
            loadDgvHDN();
           
        }
        
        void loadDgvHDN()
        {
            ImportingInvoices[] importingInvoices = ImportingInvoices.Find();
            foreach (ImportingInvoices item in importingInvoices)
            {
                Button btn = new Button();
                btn.Width = 110;
                btn.Height = 80;
                btn.Text = item.Id.ToString();
                btn.Click += (object sender, EventArgs e) =>
                {
                    panel1.Visible = true;
                    LoadThongTinBill(item.Id);
                };
                flpHDN.Controls.Add(btn);
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
            lbId.Text = id.ToString();
            ImportingInvoices_Info[] list = ImportingInvoices_Info.Find(id);
            dataGridView1.DataSource = list;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            getImportingInvoices_Info().Save();
            LoadThongTinBill(int.Parse(lbId.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormManagement form = new FormManagement();
            form.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Xoas

        }
    }
}
