using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Tests
{
    [TestClass()]
    public class Bill_DALTests
    {
        [TestMethod()]
        public void getTurnoverDayBetweenDayTest()
        {
            try
            {
                Bill_DAL dal = new Bill_DAL();
                object dt = dal.getTurnoverDayBetweenDay(new DateTime(0,4,1) , DateTime.Now);
                int num = Convert.ToInt32(dt);
                Console.WriteLine();
            }catch(Exception ex) { throw ex; }
        }

        [TestMethod()]
        public void FindBillDayBetweenDayTest()
        {

        }
    }
}