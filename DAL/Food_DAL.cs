using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class Food_DAL : ICRUD
    {
        public DataTable Find(dynamic key = null)
        {
            try
            {
            DataTable dt = null;
            if (key == null) { dt = DataProvider.Instance.ExecuteQuery("select * from Food"); }
            else { dt = DataProvider.Instance.ExecuteQuery($"select * from Food where NameF = N'{key.NameF}'"); }
            return dt;

            }catch(Exception err) { throw err; }
        }
        public void Save(dynamic obj)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery($"select * from Food where NameF = N'{obj.NameF}'");
                if (dt.Rows.Count > 0)
                {
                    string query = $"update Food set Category = N'{obj.Category}' , Price = {obj.Price} where NameF = N'{obj.NameF}'";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
                else
                {
                    string query = $"insert into Food values(N'{obj.NameF}' , N'{obj.Category}' , {obj.Price})";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getCategory()
        {
            return DataProvider.Instance.ExecuteQuery("select Category from food group by Category");
        }
        public DataTable FindWithCategory(string category)
        {
            return DataProvider.Instance.ExecuteQuery($"select * from food where category = N'{category}'");
        }

        public void Delete(dynamic obj)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery($"delete Food where NameF = N'{obj.NameF}'");

            }
            catch (Exception err) { throw err; }
        }
        public DataTable FindApproximateNameF(string NameF)
        {
            return DataProvider.Instance.ExecuteQuery($"select * from food where NameF like N'%{NameF}%'");

        }
        
    }
}
