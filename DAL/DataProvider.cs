using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DataProvider
    {
        private string str = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_CuaHang;Integrated Security=True";
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) { instance = new DataProvider(); } return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] arr = null) 
        {
            DataTable dt = new DataTable();
            using (SqlConnection conne = new SqlConnection(str))
            {
                conne.Open();
                SqlCommand cmd = new SqlCommand(query, conne);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conne.Close();
            }
            return dt;
        }
        public int ExecuteNonQuery(string query, object[] arr = null) 
        {
            int dt = 0;
            using (SqlConnection conne = new SqlConnection(str))
            {
                conne.Open();
                SqlCommand cmd = new SqlCommand(query, conne);
                dt = cmd.ExecuteNonQuery();
                conne.Close();
            }
            return dt;
        }
        public object ExecutesScalar(string query, object[] arr = null) 
        {
            object dt = 0;
            using (SqlConnection conne = new SqlConnection(str))
            {
                conne.Open();
                SqlCommand cmd = new SqlCommand(query, conne);
                dt = cmd.ExecuteScalar();
                conne.Close();
            }
            return dt;
        }
    }
}
