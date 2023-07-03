using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Bill_DAL : ICRUD
    {
        public void Delete(dynamic obj)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery($"delete Bill where Id = '{obj.Id}'");

            }
            catch (Exception err) { throw err; }
        }

        public DataTable Find(dynamic key)
        {
            try
            {
            return DataProvider.Instance.ExecuteQuery($"select * from Bill where id = {key.Id}");

            }
            catch (Exception err) { throw err; }
        }
        public DataTable Find()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery($"select * from Bill where status = 1");


            }
            catch (Exception err) { throw err; }
        }

        public void Save(dynamic obj)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery($"select * from Bill where Id = {obj.Id}");
                if (dt.Rows.Count > 0)
                {
                    string query = $"update Bill set Status = {obj.Status}  , IdTb = {obj.IdTb} , DateIn = '{obj.DateIn}' , DateOut = '{obj.DateOut}', Discount = {obj.Discount} , Note = N'{obj.Note}' where Id = {obj.Id}";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
                else
                {
                    string query = $"insert into Bill(IdTb , DateIn , DateOut , Discount , note) values({obj.IdTb} ,getDate() , getDate(),{obj.Discount} , N'{obj.Note}')";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
            }
            catch (Exception err) { throw err; }
           
        }

        
        public object getTotal(int idbill)
        {
            string query = $"SELECT SUM(Food.Price*Bill_Info.Amount)FROM Bill,Bill_Info,Food where Bill.Id = Bill_Info.IdBill and bill.Id = {idbill} and Bill_Info.NameF = Food.NameF";
            return DataProvider.Instance.ExecutesScalar(query);
        }
        public DataTable FindBillForTable(int IdTb)
        {
            return DataProvider.Instance.ExecuteQuery($"select * from Bill where idtb = {IdTb} and status = 0");
        }
        public DataTable FindBillDayBetweenDay(DateTime FirstDay , DateTime SecondDay)
        {
            return DataProvider.Instance.ExecuteQuery($"select * from Bill where status = 1 and DateIn between '{FirstDay.ToString("yyyy/MM/dd")}' and '{SecondDay.AddDays(1).ToString("yyyy/MM/dd")}'");
        }
        public object getTurnoverDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            string query = $"SELECT SUM(Food.Price*Bill_Info.Amount)FROM Bill,Bill_Info,Food where Bill.Id = Bill_Info.IdBill and " +
                $"DateIn between '{FirstDay.ToString("yyyy/MM/dd")}' and '{SecondDay.AddDays(1).ToString("yyyy/MM/dd")}'" +
                $" and Bill_Info.NameF = Food.NameF";
            return DataProvider.Instance.ExecutesScalar(query);

        }
        public void MergeBill(int firstId , int secondId)
        {
            string query = $"UPDATE Bill_Info SET IdBill = {secondId} WHERE IdBill = {firstId}";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

    }
}
