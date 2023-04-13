using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Food_BUS
    {
        private readonly Food_DAL DAL = new Food_DAL();
        public string[] getCategory()
        {
            DataTable dt = DAL.getCategory();
            string[] cates = new string[dt.Rows.Count];
            for (int i = 0; i < cates.Length; i++)
            {
                cates[i] = dt.Rows[i][0].ToString();
            }
            return cates;
        }

        public DataTable FindApproximateNameF(string NameF)
        {
            return DAL.FindApproximateNameF(NameF);
        }
        public DataTable FindWithCategory(string category)
        {
            return DAL.FindWithCategory(category);
        }
        
    }
}
