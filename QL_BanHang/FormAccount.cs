using DTO;
using System;
using System.Windows.Forms;

namespace QL_BanHang
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
            LoadTaiKhoan();
        }
        void LoadTaiKhoan()
        {
            Account[] accounts = Account.Find();
            dgvTaiKhoan.DataSource = accounts;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            FormAdmin form = new FormAdmin();   
            form.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn sửa không", "sửa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                try
                {
                    Account account = new Account(tbTk.Text , tbMk.Text , tbCV.Text);
                    account.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("sửa thất bại");
                }
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            tbTk.Text = dgvTaiKhoan.Rows[index].Cells[0].Value.ToString();
            tbMk.Text = dgvTaiKhoan.Rows[index].Cells[1].Value.ToString();
            tbCV.Text = dgvTaiKhoan.Rows[index].Cells[2].Value.ToString();
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Account account = new Account(tbTk.Text, tbMk.Text, tbCV.Text);
                account.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Xóa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                try
                {
                    Account acc = new Account();
                    acc.Username = tbTk.Text;
                    acc.getElementById();
                    acc.Delete();
                    LoadTaiKhoan();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
            }
        }
    }
}
