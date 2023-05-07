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
                string query = $"EXEC AddOrUpdateImportingInvoiceInfo @Id = {obj.Id}, @IdBill = {obj.IdBill}, @NameF = '{obj.NameF}', @Amount = {obj.Amount}, @Price = {obj.Price}";
                DataProvider.Instance.ExecuteNonQuery(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
