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
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new Exception("Đối tượng truyền vào khổng phải là 1 Table");
            }
        }
        public void Save(dynamic obj)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery($"select * from TableFood where Id = {obj.AHGFAJKSF}");
                if(dt.Rows.Count > 0)
                {
                    string query = $"update TableFood set status = {obj.Status} where Id = {obj.Id}";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
                else
                {
                    string query = $"insert into TableFood(status) values ({obj.Status})";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
            }catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new Exception("Đối tượng truyền vào khổng phải là 1 Table");
            }
        }
        public object CountTable(int status = -1)
        {
            if(status == -1) {
                return DataProvider.Instance.ExecutesScalar($"select Count(*) from TableFood"); }
            else {
                return DataProvider.Instance.ExecutesScalar($"select Count(*) from TableFood where Status = {status}");
            }
        }


    }
}
