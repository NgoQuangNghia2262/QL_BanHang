using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Food
    {
        private readonly Food_BUS BUS = new Food_BUS();
        //Atri
        private string _nameF;
        private string _category;
        private double _price;
        public Food(){ }
        public Food(string name ,  double price , string category)
        {
            _nameF = name;
            Category = category;
            Price = price;
        }
        private Food(DataRow row)
        {
            _nameF = row["NameF"].ToString();
            Category = row["Category"].ToString();
            Price = double.Parse(row["Price"].ToString());

        }
        public string NameF { get => _nameF; }
        public string Category { get => _category; set => _category = value; }
        public double Price { get => _price; set => _price = value; }
        public Ingredient[] Ingredients
        {
            get
            {
                Ingredient ingredient = new Ingredient();
                Ingredient[] ingredients = Ingredient.getElementByNameF(NameF);
                return ingredients;
            }
        }
        public void SubIngredient()
        {
            foreach (Ingredient item in Ingredients)
            {
                item.Inventory -= item.Amount;
                item.Save();
            }
        }
        public void AddIngredient()
        {
            foreach (Ingredient item in Ingredients)
            {
                item.Inventory += item.Amount;
                item.Save();
            }
        }
        private static Food[] ConvertDataTableToDTO(DataTable dt)
        {
            Food[] foods = new Food[dt.Rows.Count];
            for (int i = 0; i < foods.Length; i++)
            {
                foods[i] = new Food(dt.Rows[i]);
            }
            return foods;
        }
        public static string[] getCategory()
        {
            Food_BUS BUS = new Food_BUS();
            return BUS.getCategory();
        }
        public static Food[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(new Food());
            return ConvertDataTableToDTO(dt);
        }
        public Food Find(string key)
        {
            try
            {
                this._nameF = key;
                DataTable dt = CRUD.Instance.Find(this);
                return new Food(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
        }
        public static Food[] FindWithCategory(string category)
        {
            Food_BUS BUS = new Food_BUS();
            DataTable dt = BUS.FindWithCategory(category);
            return ConvertDataTableToDTO(dt);
        }
        public static Food[] FindApproximateNameF(string nameF)
        {
            Food_BUS BUS = new Food_BUS();
            DataTable dt = BUS.FindApproximateNameF(nameF);
            return ConvertDataTableToDTO(dt);
        }
        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public void Delete()
        {
            CRUD.Instance.Delete(this);
        }

    }
}
