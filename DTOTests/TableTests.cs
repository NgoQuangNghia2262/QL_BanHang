using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void TableTest()
        {
            //Assert.Fail();
        }
       

        [TestMethod()]
        public void SaveTest()
        {
            Table tb = new Table();
            tb.Save();
        }

        [TestMethod()]
        public void FindTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void FindTest1()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void getBillTest()
        {
            Table tb = new Table();
            Bill bl = tb.bill;
            Console.WriteLine();

        }
    }
}