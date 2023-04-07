using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill
    {
        private int _id;
        private int _status;
        private int _idTb;
        private DateTime _dateIn;
        private DateTime _dateOut;
        private double _discount;
        private string _note;
        public Bill() { _id = 0; }
        public Bill(int status, int idTb, DateTime dateIn, DateTime dateOut, double discount, string note)
        {
            _id = 0;
            Status = status;
            IdTb = idTb;
            DateIn = dateIn;
            DateOut = dateOut;
            Discount = discount;
            Note = note;
        }
        private Bill(DataRow row)
        {
            _id = int.Parse(row["Id"].ToString());
            Status = int.Parse(row["Status"].ToString());
            IdTb = int.Parse(row["IdTb"].ToString());
            DateIn = DateTime.Parse(row["DateIn"].ToString());
            DateOut = DateTime.Parse(row["DateOut"].ToString());
            Discount = double.Parse(row["Discount"].ToString());
            Note = row["Note"].ToString();
        }
        public int Id { get => _id;}
        public int Status { get => _status; set => _status = value; }
        public int IdTb { get => _idTb; set => _idTb = value; }
        public DateTime DateIn { get => _dateIn; set => _dateIn = value; }
        public DateTime DateOut { get => _dateOut; set => _dateOut = value; }
        public double Discount { get => _discount; set => _discount = value; }
        public string Note { get => _note; set => _note = value; }

        public Bill_Info[] bill_Info
        {
            get
            {
                Bill_Info instance = new Bill_Info();
                return instance.Find(Id.ToString());
            }
        }
        public double Total
        {
            get
            {
                Bill_BUS bus = new Bill_BUS();
                return bus.getTotal(Id);
            }
        }


        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public Bill[] Find()
        {
            DataTable dt = CRUD.Instance.FindALl(this);
            return ConvertDataTableToBill(dt); 
        }
        private Bill[] ConvertDataTableToBill(DataTable dt)
        {
            Bill[] instance = new Bill[dt.Rows.Count];
            for (int i = 0; i < instance.Length; i++)
            {
                instance[i] = new Bill(dt.Rows[i]);
            }
            return instance;
        }
        public Bill[] FindBillDayBetweenDay(DateTime FirstDay , DateTime SecondDay)
        {
            Bill_BUS bus = new Bill_BUS();
            DataTable dt = bus.FindBillDayBetweenDay(FirstDay , SecondDay);
            return ConvertDataTableToBill(dt);
        }
       

        public Bill FindBillForTable(string idtb)
        {
            Bill_BUS bus = new Bill_BUS();
            DataTable dt = bus.FindBillForTable(idtb);
            return new Bill(dt.Rows[0]);
        }

        //Pra : id bàn(Chỉ lấy ra bill chưa tt của bàn)
        public Bill Find(string idbill)
        {
            this._id = int.Parse(idbill);
            DataTable dt = CRUD.Instance.Find(this);
            return new Bill(dt.Rows[0]);
        }
        
    }
}
