using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Table_DAL : ICRUD
    {
        public void Delete(dynamic obj) // kh muốn xóa bàn
        {
            throw new NotImplementedException();
        }

        public DataTable Find(dynamic key = null)
        {
            try
            {
                DataTable dt = null;
                if (key == null) { dt = DataProvider.Instance.ExecuteQuery("select * from TableFood"); }
                else { dt = DataProvider.Instance.ExecuteQuery($"select * from TableFood where id = {key.Id}"); }
                return dt;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        public void Save(dynamic obj)
        {
            try
            {
                string query = $"insert";
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
