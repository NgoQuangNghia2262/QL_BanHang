using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BUS
{
    public class Ingredient_BUS
    {
        private Ingredient_DAL DAL = new Ingredient_DAL();
        public DataTable getIngredientsForFood(string nameFood)
        {
            if (!string.IsNullOrEmpty(nameFood)) { return DAL.getIngredientsForFood(nameFood); }
            else { throw new ArgumentNullException("arg phải khác null"); }
        }
        public double getInventory(string Name)
        {
            return Convert.ToDouble(DAL.getInventory(Name));
        }
        public DataTable groupByName()
        {
            return DAL.groupByName();
        }
    }
}
