using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Table
    {
        private int _id;
        private int _status;
        
        public Table() { }
        public Table(int id) { _id = id; }

        private Table(DataRow row)
        {
            _id = int.Parse(row["Id"].ToString());
            Status = int.Parse(row["Status"].ToString());
           
        }
        public int Id { get => _id; }
        public int Status { get => _status; set => _status = value; }
        public static int CountWithStatus(int status)
        {
            Table_BUS bus = new Table_BUS();
            return bus.CountTable(status);
        }
        public static int Count
        {
            get
            {
                Table_BUS bus = new Table_BUS();
                return bus.CountTable();
            }
        }
        public Bill bill
        {
            get
            {
                try
                {
                    Bill bill = new Bill();
                    bill.IdTb = this.Id;
                    bill.FindBillForTable();
                    return bill;
                }
                catch (Exception) {
                    Bill bill = new Bill();
                    bill.IdTb = this.Id;
                    bill.Save();
                    bill.FindBillForTable();
                    return bill;
                }
            }
        }

        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public static Table[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(new Table());
            Table[] tables = new Table[dt.Rows.Count];
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new Table(dt.Rows[i]);
            }
            return tables;
        }
        public static Table Find(int key)
        {
            try
            {
                DataTable dt = CRUD.Instance.Find(new Table(key));
                return new Table(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public void getElementById()
        {
            try
            {
                if (Id <= 0) { throw new FormatException("Id của Bill phỉa lớn hơn 0"); }
                DataTable dt = CRUD.Instance.Find(this);
                DataRow row = dt.Rows[0];
                Status = int.Parse(row["Status"].ToString());
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Không tìm thấy phần tử trong danh sách.");
            }
        }

    }
}
