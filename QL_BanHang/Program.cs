using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanHang
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Food> list = new List<Food>() {Food.Find("Gà Sốt Tiêu Xanh"),Food.Find("Bánh mì") };
            Application.Run(new FormTable());
        }
    }
}
