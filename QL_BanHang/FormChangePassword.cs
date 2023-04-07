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
    public partial class FormChangePassword : Form
    {
        private Account _tk;
        public FormChangePassword(Account _tk)
        {
            this._tk = _tk;
            InitializeComponent();
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {

        }
        bool Check()
        {
            bool mkcu = _tk.Password == tbMKCu.Text;
            bool mkmoi = tbMK.Text.Length > 0;
            bool mkmoi2 = tbMK2.Text == tbMK.Text;
            return mkcu && mkmoi && mkmoi2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn sửa không", "sửa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                try
                {
                    if (Check())
                    {
                        _tk.Password = tbMK.Text;
                        _tk.Save();
                        MessageBox.Show("Đổi Thành Công");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Thông Tin Không Hợp Lệ");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("sửa thất bại");
                }
            }
        }
    }
}
