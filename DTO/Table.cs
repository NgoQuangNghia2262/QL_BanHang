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
                Bill bill = new Bill();
                return bill.FindBillForTable(Id);
            }
        }

        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public Table[] Find()
        {
            DataTable dt = CRUD.Instance.FindALl(this);
            Table[] tables = new Table[dt.Rows.Count];
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new Table(dt.Rows[i]);
            }
            return tables;
        }
        public Table Find(int key)
        {
            this._id = key;
            DataTable dt = CRUD.Instance.Find(this);
            return new Table(dt.Rows[0]);
        }
     
    }
}
