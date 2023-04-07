using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Account_DAL : ICRUD
    {
        public void Delete(dynamic obj)
        {
            DataProvider.Instance.ExecuteNonQuery($"delete Account where Username = '{obj.Username}'");
        }
        public DataTable Find(dynamic obj = null)
        {
            try
            {
                DataTable dt = null;
                if (obj == null) { dt = DataProvider.Instance.ExecuteQuery("select * from Account"); }
                else { dt = DataProvider.Instance.ExecuteQuery($"select * from Account where Username = '{obj.Username}'"); }
                return dt;

            }
            catch (Exception err) { throw err; }
        }

        public void Save(dynamic obj)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery($"select * from Account where Username = '{obj.Username}'");
                if(dt.Rows.Count > 0)
                {
                    string query = $"update Account set Password = '{obj.Password}' , Category = '{obj.Category}' where Username = '{obj.Username}";
                    DataProvider.Instance.ExecuteQuery(query);
                }
                else
                {
                string query = $"insert into Account values('{obj.Username}' , '{obj.Password}' , '{obj.Category}')";
                DataProvider.Instance.ExecuteQuery(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
