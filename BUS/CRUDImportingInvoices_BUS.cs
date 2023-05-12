using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CRUDImportingInvoices_BUS : ICRUD
    {
        private readonly ImportingInvoices_DAL DAL = new ImportingInvoices_DAL();

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
            return DAL.Find();
        }
        public void Save(object obj)
        {
            if (Check())
            {
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
