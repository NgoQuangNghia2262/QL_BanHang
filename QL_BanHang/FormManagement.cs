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
    public partial class FormManagement : Form
    {
        public FormManagement()
        {
            InitializeComponent();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAccount form = new FormAccount();
            form.ShowDialog();
            this.Close();
        }

        private void mónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFood form = new FormFood();
            form.ShowDialog();
            this.Close();
            
        }

        private void hóaĐơnBánToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormAdmin form = new FormAdmin();
            form.ShowDialog();
            this.Close();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormImportingInvoices form = new FormImportingInvoices();
            form.ShowDialog();
            this.Close();
        }

        private void bànĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTable form = new FormTable();
            form.ShowDialog();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword form = new FormChangePassword(Account.Find("admin"));
            form.ShowDialog();
        }
    }
}
