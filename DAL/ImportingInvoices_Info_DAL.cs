using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImportingInvoices_Info_DAL : ICRUD
    {
        public void Delete(dynamic obj)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery($"delete Bill_Info where Id = '{obj.Id}'");

            }
            catch (Exception err) { throw err; }
        }
        public DataTable Find(dynamic obj = null)
        {
            try
            {
                DataTable dt = null;
                if (obj == null) { dt = DataProvider.Instance.ExecuteQuery("select * from Bill_Info"); }
                else { dt = DataProvider.Instance.ExecuteQuery($"select * from Bill_Info where idbill = {obj.IdBill}"); }
                return dt;

            }
            catch (Exception err) { throw err; }
        }

        public void Save(dynamic obj)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery($"select * from Bill_Info ,Bill where Bill_Info.idbill= Bill.id and Bill_Info.idbill = {obj.IdBill} and NameF = N'{obj.NameF}' and Status = 0");
                if (dt.Rows.Count > 0)
                {
                    string query = $"update Bill_Info set Amount = {obj.Amount} where idbill = {obj.IdBill} and NameF = N'{obj.NameF}'";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
                else
                {
                    string query = $"insert into Bill_Info(IdBill , NameF , Amount) values({obj.IdBill} , N'{obj.NameF}' , {obj.Amount})";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getTopFoodDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            string query1 = "select top(5) NameF ,SUM(amount) as Amount from Bill_Info , Bill where Bill.Id = IdBill ";
            string query2 = $"and DateIn between '{FirstDay.ToString("yyyy/MM/dd")}' and '{SecondDay.AddDays(1).ToString("yyyy/MM/dd")}'";
            string query = query1 + query2 + "group by NameF ORDER BY Sum(Amount) DESC";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
