using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BanHang
{
    public class KetNoi
    {
        private string str = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_BanHang;Integrated Security=True"; // Chuỗi kết nối
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection conne = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(query, conne);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conne.Close();

            return dt; // Sau khi kết thúc trả về 1 datatable
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
    }
}
