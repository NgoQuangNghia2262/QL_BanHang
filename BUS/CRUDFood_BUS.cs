using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class CRUDFood_BUS : ICRUD
    {
        Food_DAL DAL = new Food_DAL();
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
            throw new NotImplementedException();
        }

        public DataTable Find(object key)
        {
            return DAL.Find(key);
        }

        public void Save(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
