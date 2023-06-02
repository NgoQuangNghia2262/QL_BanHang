using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;

namespace DTO
{
    public class Account 
    {
        
        private string _username;
        private string _password;
        private string _category;
        public Account()
        {

        }
        private Account(DataRow row)
        {
            _username = row["username"].ToString().Trim();
            Password = row["password"].ToString().Trim();
            Category = row["category"].ToString().Trim();
        }
        public Account(string username)
        {
            _username = username;
        }
        public Account(string username, string password, string category)
        {
            _username = username;
            Password = password;
            Category = category;
        }

        public string Username { get => _username; }
        public string Password { get => _password; set => _password = value; }
        public string Category { get => _category; set => _category = value; }

        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public void Delete()
        {
            CRUD.Instance.Delete(this);
        }
        public static Account[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(new Account());
            Account[] accounts = new Account[dt.Rows.Count];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account(dt.Rows[i]);
            }
            return accounts;
        }
        public static Account Find(string username)
        {
            try
            {
                DataTable dt = CRUD.Instance.Find(new Account(username));
                return new Account(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public void getElementById()
        {
            try
            {
                DataTable dt = CRUD.Instance.Find(this);
                DataRow row = dt.Rows[0];
                Password = row["password"].ToString().Trim();
                Category = row["category"].ToString().Trim();
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Không tìm thấy phần tử trong danh sách.");
            }
        }
    }
}
