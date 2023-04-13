using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImportingInvoices_Info
    {
        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public void Delete()
        {
            CRUD.Instance.Delete(this);
        }
    }
}
