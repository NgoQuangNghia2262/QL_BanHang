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
        public DataTable FindBillForTable(int idtb)
        {
                if(idtb < 1) { throw new Exception("Id bàn không hợp lệ"); }
                return DAL.FindBillForTable(idtb);
          
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
            catch (InvalidCastException) { return 0; }
        }
    }
}
