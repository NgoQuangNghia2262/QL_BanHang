using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO
{
    public class ImportingInvoices
    {
        private int _id;
        private DateTime _date;
        private string _note;
        private string _suppliers;

        public int Id { get => _id;}
        public DateTime Date { get => _date; set => _date = value; }
        public string Note { get => _note; set => _note = value; }
        public string Suppliers { get => _suppliers; set => _suppliers = value; }
        public ImportingInvoices_Info[] ImportingInvoices_Infos
        {
            get
            {
                ImportingInvoices_Info instance = new ImportingInvoices_Info();
                return instance.Find(Id);
            }
        }

        public ImportingInvoices() {   }

        public ImportingInvoices(int id, DateTime date, string note, string suppliers)
        {
            _id = id;
            Date = date;
            Note = note;
            Suppliers = suppliers;
        }
        private ImportingInvoices(DataRow row)
        {
            _id = int.Parse(row["Id"].ToString());
            Date = DateTime.Parse(row["Date"].ToString());
            Note = row["Note"].ToString();
            Suppliers = row["Suppliers"].ToString();

        }
        private ImportingInvoices[] ConvertDataTableToDTO(DataTable dt)
        {
            ImportingInvoices[] foods = new ImportingInvoices[dt.Rows.Count];
            for (int i = 0; i < foods.Length; i++)
            {
                foods[i] = new ImportingInvoices(dt.Rows[i]);
            }
            return foods;
        }
        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public void Delete()
        {
            CRUD.Instance.Delete(this);
        }
        public ImportingInvoices[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(this);
            ImportingInvoices[] foods = ConvertDataTableToDTO(dt);
            return foods;
        }
        public ImportingInvoices Find(string key)
        {
            try
            {
                this._id = int.Parse(key);
                DataTable dt = CRUD.Instance.Find(this);
                return new ImportingInvoices(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
    }
}
