using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class CRUDImportingInvoices_Info_BUS : ICRUD
    {
        private readonly ImportingInvoices_Info_DAL DAL = new ImportingInvoices_Info_DAL();
        private bool Check(dynamic obj)
        {
            bool checkId = obj.Id >= 0;
            return checkId;
        }
        public void Delete(object Key)
        {
            if (Check(Key))
            {
                DAL.Delete(Key);
            }
            else
            {
                throw new Exception("Thông tin không hợp lệ !!!");
            }
        }

        public DataTable Find(object key)
        {
            if (Check(key))
            {
                return DAL.Find(key);
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

        public void Save(object obj)
        {
            if (Check(obj))
            {
                DAL.Save(obj);
            }
            else
            {
                throw new Exception("Thông tin không hợp lệ !!!");
            }

        }
    }
}
