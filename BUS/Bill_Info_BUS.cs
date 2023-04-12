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
        Bill_Info_DAL DAL = new Bill_Info_DAL();
        public DataTable getTopFoodDayBetweenDay(DateTime FirstDay, DateTime SecondDay)
        {
            if (FirstDay <= SecondDay)
            {
                return DAL.getTopFoodDayBetweenDay(FirstDay, SecondDay);
            }
            else { throw new ArgumentOutOfRangeException(nameof(SecondDay), $"Para chuyền vào không hợp lệ SecondDay phải < FirstDay"); }
           
        }
    }
}
