using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang
{
    public partial class FormLogIn : Form
    {
        Account account = new Account();
        public FormLogIn()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Account result = account.Find(tbUser.Text);
            if (result.Password != tbPass.Text)
            {
                MessageBox.Show("Tài khoản hoặc mật khấu không đúng");
            }
            else
            {
                Hide();
                FormMain form = new FormMain();
                if (result.Category.Trim() != "admin") 
                {
                }
                MessageBox.Show("Đăng Nhập Thành Công");
                form.ShowDialog();
                Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkmk.Checked != true)
            {
                tbPass.UseSystemPasswordChar = true;
            }
            else { tbPass.UseSystemPasswordChar = false; }
        }
    }
}
