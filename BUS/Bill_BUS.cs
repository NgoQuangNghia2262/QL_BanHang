using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bill_BUS
    {
        private Bill_DAL DAL = new Bill_DAL();
        public double getTotal(string idbill)
        {
            try
            {
                int i = 0;
                if (int.TryParse(idbill, out i))
                {
                    double result = Convert.ToDouble(DAL.getTotal(idbill));
                    return result;
                }
                else { throw new Exception("Parameters phải là 1 id của Bill"); }
            }
            catch (InvalidCastException) { return 0; }
        }
        public DataTable FindBillForTable(string idtb)
        {
            int i = 0;
            if(int.TryParse(idtb, out i))
            {
                return DAL.FindBillForTable(idtb);
            }
            else { throw new Exception("Parameters phải là 1 id của table"); }
        }
        public DataTable FindBillDayBetweenDay(DateTime FirstDay , DateTime SecondDay)
        {
            if(FirstDay <= SecondDay)
            {
                return DAL.FindBillDayBetweenToday(FirstDay,SecondDay);
            }
            else { throw new Exception("Ngày truyền vào phải nhỏ hơn ngày hôm nay"); }
        }
    }
}
