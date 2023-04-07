using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        private string str = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_CuaHang;Integrated Security=True";
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) { instance = new DataProvider(); } return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] arr = null) // Truy vấn 
        {
            DataTable dt = new DataTable();
            using (SqlConnection conne = new SqlConnection(str))
            {
                conne.Open();
                SqlCommand cmd = new SqlCommand(query, conne);
                if (arr != null)
                {
                    int i = 0;
                    string[] line = query.Split(' ');
                    foreach (string item in line)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, arr[i]);// item là các parameters , arr[i] là các tham số đc truyền vào
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conne.Close();
            }
            return dt;
        }
        public int ExecuteNonQuery(string query, object[] arr = null) // trả ra số dòng thêm , sửa , xóa thành công
        {
            int dt = 0;
            using (SqlConnection conne = new SqlConnection(str))
            {
                conne.Open();
                SqlCommand cmd = new SqlCommand(query, conne);
                if (arr != null)
                {
                    int i = 0;
                    string[] line = query.Split(' ');
                    foreach (string item in line)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, arr[i]);// item là các parameters , arr[i] là các tham số đc truyền vào
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteNonQuery();
                conne.Close();
            }
            return dt;
        }
        public object ExecutesScalar(string query, object[] arr = null) // Dùng đểm  số lượng , tính tổng ( hàm count(*) , sum() trong Sql)
        {
            object dt = 0;
            using (SqlConnection conne = new SqlConnection(str))
            {
                conne.Open();
                SqlCommand cmd = new SqlCommand(query, conne);
                if (arr != null)
                {
                    int i = 0;
                    string[] line = query.Split(' ');
                    foreach (string item in line)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, arr[i]);// item là các parameters , arr[i] là các tham số đc truyền vào
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteScalar();
                conne.Close();
            }
            return dt;
        }
    }
}
