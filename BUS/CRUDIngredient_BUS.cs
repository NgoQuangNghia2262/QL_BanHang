using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class CRUDIngredient_BUS : ICRUD
    {
        Ingredient_DAL DAL = new Ingredient_DAL();
        private bool Check() { return true; }
        public void Delete(object Key)
        {
            if (Check())
            {
                DAL.Delete(Key);
            }
            else
            {
                throw new Exception("Thông tin không hợp lệ !!!");
            }
        }

        public DataTable Find()
        {
            Ingredient_DAL DAL = new Ingredient_DAL();
            return DAL.Find();
        }

        public DataTable Find(object key)
        {
            Ingredient_DAL DAL = new Ingredient_DAL();
            return DAL.Find(key);
        }

        public void Save(object obj)
        {
           DAL.Save(obj);
        }
    }
}
