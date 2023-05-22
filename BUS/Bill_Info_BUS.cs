using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bill_Info_BUS
    {
       
        public static DataTable getTopFoodDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            Bill_Info_DAL DAL = new Bill_Info_DAL();
            if (FirstDay <= SecondDay)
            {
                return DAL.getTopFoodDayBetweenDay(FirstDay, SecondDay);
            }
            else { throw new ArgumentOutOfRangeException(nameof(SecondDay), $"Para chuyền vào không hợp lệ SecondDay phải < FirstDay"); }
           
        }
        public static DataTable FindAllByIdBill(int idBill)
        {
            Bill_Info_DAL DAL = new Bill_Info_DAL();
            if (idBill <= 0) { throw new ArgumentOutOfRangeException(nameof(idBill), $"Para chuyền vào không hợp lệ (Phải > 0)"); }
            return DAL.FindAllByIdBill(idBill);
        }
    }
}
