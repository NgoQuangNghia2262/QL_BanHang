using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO
{
    public class ImportingInvoices_Info
    {
        private int _id;
        private int _idBill;
        private string _nameF;
        private double _amount;
        private double _price;

        public int Id { get => _id; }
        public int IdBill { get => _idBill; set => _idBill = value; }
        public string NameF { get => _nameF; set => _nameF = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public double Price { get => _price; set => _price = value; }

        public ImportingInvoices_Info() { }
        public ImportingInvoices_Info(int id, int idBill, string nameF, double amount, double price)
        {
            _id = id;
            IdBill = idBill;
            NameF = nameF;
            Amount = amount;
            Price = price;
        }
        private ImportingInvoices_Info(DataRow row)
        {
            NameF = row["NameF"].ToString();
            _id = int.Parse(row["id"].ToString());
            IdBill = int.Parse(row["IdBill"].ToString());
            Amount = double.Parse(row["Amount"].ToString());
            Price = double.Parse(row["Price"].ToString());
        }
        private static ImportingInvoices_Info[] ConvertDataTableToDTO(DataTable dt)
        {
            ImportingInvoices_Info[] foods = new ImportingInvoices_Info[dt.Rows.Count];
            for (int i = 0; i < foods.Length; i++)
            {
                foods[i] = new ImportingInvoices_Info(dt.Rows[i]);
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
        public static ImportingInvoices_Info[] Find(int idBill = -1)
        {
            DataTable dt = new DataTable();
            if (idBill == -1)
            {
                dt = CRUD.Instance.FindAll(new ImportingInvoices_Info());
            }
            else
            {
                ImportingInvoices_Info ins = new ImportingInvoices_Info();
                ins.IdBill = idBill;
                dt = CRUD.Instance.Find(ins);
            }
            return ConvertDataTableToDTO(dt);
        }
    }
}
