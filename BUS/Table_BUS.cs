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
            if (status <= 0) { throw new ArgumentOutOfRangeException(nameof(status) , $"Status phải là 0 hoặc 1"); }
            Table_DAL DAL = new Table_DAL();
            return Convert.ToInt32(DAL.CountTable(status));
        }
        public int CountTable()
        {
            Table_DAL DAL = new Table_DAL();
            return Convert.ToInt32(DAL.CountTable());
        }
    }
}
