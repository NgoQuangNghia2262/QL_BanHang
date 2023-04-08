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
        public double getTotal(int idbill)
        {
            try
            {
                
                    double result = Convert.ToDouble(DAL.getTotal(idbill));
                    return result;
               
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
                return DAL.FindBillDayBetweenDay(FirstDay,SecondDay);
            }
            else { throw new Exception("Ngày truyền vào phải nhỏ hơn ngày hôm nay"); }
        }
        public double getTurnoverDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            try
            {
                return Convert.ToDouble(DAL.getTurnoverDayBetweenDay(FirstDay, SecondDay));
            }
            catch (Exception) { return 0; }
        }
    }
}
