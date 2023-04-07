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
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
            LoadProduct();
            LoadCate();
        }
        void LoadProduct()
        {
           
            
        }
        void LoadCate()
        {
            //var list = db.Product.GroupBy(vd => vd.CATEGORY)
            //    .Select(vd => new { Tên = vd.Key});
            //foreach (var item in list)
            //{
            //    ccbCate.Items.Add(item.Tên);
            //}
        }

        private void dgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            tbName.Text = dgvProd.Rows[index].Cells[0].Value.ToString();
            tbPrice.Text = dgvProd.Rows[index].Cells[1].Value.ToString();
            ccbCate.Text = dgvProd.Rows[index].Cells[2].Value.ToString();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            FormAdmin form = new FormAdmin();
            form.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Xóa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                try
                {
                    //Product product = db.Product.Find(tbName.Text);
                    //db.Product.Remove(product);
                    //db.SaveChanges();
                    //MessageBox.Show("Xóa Thành Công");
                    //LoadProduct();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa Thất Bại");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn sửa không", "sửa ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                try
                {
                    //Product product = db.Product.Find(tbName.Text);
                    //product.CATEGORY = ccbCate.Text;
                    //product.PRICE = double.Parse(tbPrice.Text);
                    //db.SaveChanges();
                    //MessageBox.Show("Sửa Thành Công");
                    //LoadProduct();
                }
                catch (Exception)
                {
                    MessageBox.Show("sửa thất bại");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Product product = new Product();
                //product.CATEGORY = ccbCate.Text;
                //product.NAME = tbName.Text;
                //product.PRICE = double.Parse(tbPrice.Text);
                //db.Product.Add(product);
                //db.SaveChanges();
                //MessageBox.Show("Thêm Thành Công");
                //LoadProduct();
            }
            catch(Exception)
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void tbShare_TextChanged(object sender, EventArgs e)
        {
             KetNoi ketnoi = new KetNoi();
            DataTable dt = ketnoi.ExecuteQuery($"select * from Product where name like N'%{tbShare.Text}%'");
            dgvProd.DataSource = dt;
        }
    }
}
