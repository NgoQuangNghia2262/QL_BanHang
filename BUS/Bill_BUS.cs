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
                if (idbill < 0) { throw new ArgumentOutOfRangeException(nameof(idbill), $"Para chuyền vào không hợp lệ (Phải >= 0)"); }
                double result = Convert.ToDouble(DAL.getTotal(idbill));
                return result;
            }
            catch (InvalidCastException) { return 0; }
        }
        public DataTable FindBillForTable(int idtb)
        {
            if (idtb < 0) { throw new ArgumentOutOfRangeException(nameof(idtb), $"Para chuyền vào không hợp lệ (Phải > 0)"); }
            return DAL.FindBillForTable(idtb);
          
        }
        public DataTable FindBillDayBetweenDay(DateTime FirstDay , DateTime SecondDay)
        {
            if(FirstDay <= SecondDay)
            {
                return DAL.FindBillDayBetweenDay(FirstDay,SecondDay);
            }
            else { throw new ArgumentOutOfRangeException(nameof(SecondDay), $"Para chuyền vào không hợp lệ SecondDay phải < FirstDay"); }
        }
        public double getTurnoverDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            try
            {
                if (FirstDay <= SecondDay)
                {
                    return Convert.ToDouble(DAL.getTurnoverDayBetweenDay(FirstDay, SecondDay));
                }
                else { throw new ArgumentOutOfRangeException(nameof(SecondDay), $"Para chuyền vào không hợp lệ SecondDay phải < FirstDay"); }
            }
            catch (InvalidCastException) { return 0; }
        }
        public void MergeBill(int firstId, int secondId)
        {
            if (firstId < 0 | secondId < 0) { throw new ArgumentOutOfRangeException($"Para chuyền vào không hợp lệ (Phải >= 0)"); }
            DAL.MergeBill(firstId, secondId);
        }
    }
}
