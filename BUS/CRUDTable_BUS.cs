using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class CRUDTable_BUS : ICRUD
    {
        private readonly Table_DAL DAL = new Table_DAL();
        
        private bool Check()
        {
            return true;
        }
        //Truyền vào id bàn lấy ra 1 bàn
        public DataTable Find(object key)
        {
            return DAL.Find(key);
        }
        //Lấy tát cả các bàn
        public DataTable Find()
        {
            Table_DAL DAL = new Table_DAL();
            return DAL.Find();
        }
        public void Save(object obj)
        {
            if(Check())
            {
                Table_DAL DAL = new Table_DAL();
                DAL.Save(obj);
            }
            else
            {
                throw new Exception("Thông tin nhập vào không hợp lệ !!!");
            }
        }
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

    }
}
