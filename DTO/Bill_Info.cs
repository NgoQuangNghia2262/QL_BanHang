using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill_Info
    {
        private int _id;
        private int _idBill;
        private string _nameF;
        private int _amount;
        public Bill_Info() { }

        public Bill_Info(int idBill, string nameF, int amount)
        {
            IdBill = idBill;
            NameF = nameF;
            Amount = amount;
        }

        private Bill_Info(DataRow row)
        {
            NameF = row["NameF"].ToString();
            _id = int.Parse(row["id"].ToString());
            IdBill = int.Parse(row["IdBill"].ToString());
            Amount = int.Parse(row["Amount"].ToString());

        }

        public int Id { get => _id; }
        public int IdBill { get => _idBill; set => _idBill = value; }
        public string NameF { get => _nameF; set => _nameF = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public Food food
        {
            get
            {
                Food food = new Food();
                return food.Find(NameF);
            }
        }
        public static Bill_Info[] FindAllByIdBill(int IdBill)
        {
            DataTable dt = Bill_Info_BUS.FindAllByIdBill(IdBill);
            return ConvertDataTableToDTO(dt);
        }
        public static Bill_Info[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(new Bill());
            return ConvertDataTableToDTO(dt);
        }
        public Bill_Info Find(int key)
        {
            try
            {
                this._id = key;
                DataTable dt = CRUD.Instance.Find(this);
                return new Bill_Info(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
        }

        private static Bill_Info[] ConvertDataTableToDTO(DataTable dt)
        {
            Bill_Info[] BillInfos = new Bill_Info[dt.Rows.Count];
            for (int i = 0; i < BillInfos.Length; i++)
            {
                BillInfos[i] = new Bill_Info(dt.Rows[i]);
            }
            return BillInfos;
        }
        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public static Bill_Info[] getTop5FoodDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            DataTable dt = Bill_Info_BUS.getTopFoodDayBetweenDay(FirstDay, SecondDay);
            Bill_Info[] BillInfos = new Bill_Info[dt.Rows.Count];
            for (int i = 0; i < BillInfos.Length; i++)
            {
                BillInfos[i] = new Bill_Info();
                BillInfos[i].Amount = int.Parse(dt.Rows[i]["Amount"].ToString());
                BillInfos[i].NameF = dt.Rows[i]["NameF"].ToString();
            }
            return BillInfos;
        }
        public void Delete()
        {
            CRUD.Instance.Delete(this);
        }
        public void getElementById()
        {
            try
            {
                if (Id <= 0) { throw new FormatException("Id của Bill phỉa lớn hơn 0"); }
                DataTable dt = CRUD.Instance.Find(this);
                DataRow row = dt.Rows[0];
                NameF = row["NameF"].ToString();
                IdBill = int.Parse(row["IdBill"].ToString());
                Amount = int.Parse(row["Amount"].ToString());
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Không tìm thấy phần tử trong danh sách.");
            }
        }

    }
}
