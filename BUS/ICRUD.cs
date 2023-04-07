using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal interface ICRUD
    {
        void Save(object obj);
        void Delete(object Key);
        DataTable Find();
        DataTable Find(object key);
       
    }
}
