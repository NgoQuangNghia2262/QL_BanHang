using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS.Tests
{
    [TestClass()]
    public class CRUDImportingInvoices_BUSTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            
        }

        [TestMethod()]
        public void SaveTest()
        {
            ImportingInvoices invoice = new ImportingInvoices(4, DateTime.Now, "Samsdcfvgbhdfte", "gda");
            invoice.Save();
        }
    }
}