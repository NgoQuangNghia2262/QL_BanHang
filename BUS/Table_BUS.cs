using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Table_BUS
    {
        public int CountTable(int status)
        {
            Table_DAL DAL = new Table_DAL();
            return Convert.ToInt32(DAL.CountTable(status));
        }
    }
}
