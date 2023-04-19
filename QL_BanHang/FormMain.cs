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
    public partial class FormMain : Form
    {
        private readonly Table table = new Table();
        public FormMain()
        {
            InitializeComponent();
            LoadTable();  
        }
        void LoadTable()
        {
            Table[] tables = table.Find();
            foreach (Table item in tables)
            {
                Button btn = new Button();
                btn.Text = item.Id.ToString();
                btn.Width = flpTable.Width/4 - 12;
                btn.Height = Convert.ToInt32(btn.Width * 0.625);
                if(item.Status == 1) { btn.BackColor = Color.Aqua; }
                btn.Click += (object sender, EventArgs e) =>
                {
                    this.Hide();
                    FormBill form = new FormBill(item.bill);
                    form.ShowDialog();
                    this.Close();

                };
                flpTable.Controls.Add(btn);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQLBill form = new FormQLBill();
            form.ShowDialog();
            this.Close();
        }
    }
}
