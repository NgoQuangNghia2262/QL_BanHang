﻿using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class CRUDAccount_BUS : ICRUD
    {
        Account_DAL DAL = new Account_DAL();
        private bool Check() { return true; }
        public void Delete(object Key)
        {
            if (Check())
            {
                DAL.Delete(Key);
            }
            else
            {
                throw new Exception("Thông tin không hợp lệ !!!");
            }
        }

        public DataTable Find()
        {
           return DAL.Find();
        }

        public DataTable Find(object key)
        {
            return DAL.Find(key);
        }

        public void Save(object obj)
        {
            if (Check()) { DAL.Save(obj); }
            else { throw new Exception("obj null"); }
        }
    }
}
