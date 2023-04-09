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
            Username = row["username"].ToString().Trim();
            Password = row["password"].ToString().Trim();
            Category = row["category"].ToString().Trim();
        }
        public Account(string username, string password, string category)
        {
            Username = username;
            Password = password;
            Category = category;
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Category { get => _category; set => _category = value; }

        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public Account[] Find()
        {
            DataTable dt = CRUD.Instance.FindALl(this);
            Account[] accounts = new Account[dt.Rows.Count];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account(dt.Rows[i]);
            }
            return accounts;
        }
        public Account Find(string username)
        {
            try
            {
                this.Username = username;
                DataTable dt = CRUD.Instance.Find(this);
                return new Account(dt.Rows[0]);
            }
            catch(IndexOutOfRangeException ) { return new Account(); }
            
        }
    }
}
