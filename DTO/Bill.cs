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
        private Bill_BUS bus = new Bill_BUS();
        public Bill() { _id = 0; }
        public Bill(int id) { _id = id; }
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
                if(Id > 0) { return Bill_Info.FindAllByIdBill(Id); }
                else { return null; }
            }
        }
        public double Total
        {
            get
            {
                return bus.getTotal(Id);
            }
        }

        public void Delete()
        {
            CRUD.Instance.Delete(this);
        }
        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public double getTurnoverDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            return bus.getTurnoverDayBetweenDay(FirstDay, SecondDay);
        }

        public void FindBillForTable()
        {
            try
            {
                if (IdTb <= 0) { throw new FormatException("Id của Bill phỉa lớn hơn 0"); }
                Bill_BUS bus = new Bill_BUS();
                DataTable dt = bus.FindBillForTable(this.IdTb);
                DataRow row = dt.Rows[0];
                _id = int.Parse(row["Id"].ToString());
                Status = int.Parse(row["Status"].ToString());
                DateIn = DateTime.Parse(row["DateIn"].ToString());
                DateOut = DateTime.Parse(row["DateOut"].ToString());
                Discount = double.Parse(row["Discount"].ToString());
                Note = row["Note"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Không tìm thấy phần tử trong danh sách.");
            }
        }
        public void getElementById()
        {
            try
            {
                if (Id <= 0) { throw new FormatException("Id của Bill phỉa lớn hơn 0"); }
                DataTable dt = CRUD.Instance.Find(this);
                DataRow row = dt.Rows[0];
                Status = int.Parse(row["Status"].ToString());
                IdTb = int.Parse(row["IdTb"].ToString());
                DateIn = DateTime.Parse(row["DateIn"].ToString());
                DateOut = DateTime.Parse(row["DateOut"].ToString());
                Discount = double.Parse(row["Discount"].ToString());
                Note = row["Note"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Không tìm thấy phần tử trong danh sách.");
            }

        }

        public static Bill Find(int idbill)
        {
            try
            {
                if(idbill < 0) { throw new Exception("Id phải > 0"); }
                DataTable dt = CRUD.Instance.Find(new Bill(idbill));
                return new Bill(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
        }

        public static Bill[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(new Bill());
            return ConvertDataTableToDTO(dt); 
        }
        private static Bill[] ConvertDataTableToDTO(DataTable dt)
        {
            Bill[] instance = new Bill[dt.Rows.Count];
            for (int i = 0; i < instance.Length; i++)
            {
                instance[i] = new Bill(dt.Rows[i]);
            }
            return instance;
        }
        public static Bill[] FindBillDayBetweenDay(DateTime FirstDay , DateTime SecondDay)
        {
            Bill_BUS bus = new Bill_BUS();
            DataTable dt = bus.FindBillDayBetweenDay(FirstDay , SecondDay);
            return ConvertDataTableToDTO(dt);
        }
    }
}
