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
            ImportingInvoices bill = new ImportingInvoices();
            dgvHDB.DataSource = bill.Find();
        }
    }
}
