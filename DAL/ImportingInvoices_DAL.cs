﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImportingInvoices_DAL
    {
        public void Delete(dynamic obj)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery($"delete ImportingInvoices where Id = '{obj.Id}'");

            }
            catch (Exception err) { throw err; }
        }
        public DataTable Find(dynamic obj = null)
        {
            try
            {
                DataTable dt = null;
                if (obj == null) { dt = DataProvider.Instance.ExecuteQuery("select * from ImportingInvoices"); }
                else { dt = DataProvider.Instance.ExecuteQuery($"select * from ImportingInvoices where id = '{obj.IdBill}'"); }
                return dt;

            }
            catch (Exception err) { throw err; }
        }

        public void Save(dynamic obj)
        {
            try
            {
                try
                {
                    DataTable dt = DataProvider.Instance.ExecuteQuery($"select * from ImportingInvoices where Id = {obj.Id}");
                    if (dt.Rows.Count > 0)
                    {
                        string query = $"update ImportingInvoices set Date = '{obj.Date}', Suppliers = '{obj.Suppliers}' , Note = N'{obj.Note}' where Id = '{obj.Id}'";
                        DataProvider.Instance.ExecuteNonQuery(query);
                    }
                    else
                    {
                        string query = $"insert into ImportingInvoices( Date , Suppliers , note) values(getDate() , '{obj.Suppliers}' , N'{obj.Note}')";
                        DataProvider.Instance.ExecuteNonQuery(query);
                    }
                }
                catch (Exception err) { throw err; }
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
