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


        public Bill_Info[] Find(int idBill = -1)
        {
            DataTable dt = new DataTable();
            if(idBill == -1)
            {
                dt = CRUD.Instance.FindAll(this);
            }
            else {
                this.IdBill = idBill;
                dt = CRUD.Instance.Find(this); 
            }
            return ConvertDataTableToDTO(dt);
        }
        private Bill_Info[] ConvertDataTableToDTO(DataTable dt)
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
        public Bill_Info[] getTop5FoodDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            Bill_Info_BUS bus = new Bill_Info_BUS();
            DataTable dt = bus.getTopFoodDayBetweenDay(FirstDay, SecondDay);
            Bill_Info[] BillInfos = new Bill_Info[dt.Rows.Count];
            for (int i = 0; i < BillInfos.Length; i++)
            {
                BillInfos[i] = new Bill_Info();
                BillInfos[i].Amount = int.Parse(dt.Rows[i]["Amount"].ToString());
                BillInfos[i].NameF = dt.Rows[i]["NameF"].ToString();
            }
            return BillInfos;
        }


    }
}
