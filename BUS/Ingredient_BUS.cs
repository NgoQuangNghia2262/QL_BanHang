using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Ingredient_BUS
    {
        private Ingredient_DAL DAL = new Ingredient_DAL();
        public DataTable getIngredientsForFood(string nameFood)
        {
            if (!string.IsNullOrEmpty(nameFood)) { return DAL.getIngredientsForFood(nameFood); }
            else { throw new Exception("Sai tên food"); }
        }
       
    }
}
