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
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
            LoadDgv();
        }
        void LoadDgv()
        {
            Table[] tables = Table.Find();
            dataGridView1.DataSource = tables;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult dia = MessageBox.Show("Bạn có muốn thêm bàn không", "Thêm ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                Table newTable = new Table();
                newTable.Save();
                LoadDgv();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FormManagement form = new FormManagement();
            form.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Xóa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
