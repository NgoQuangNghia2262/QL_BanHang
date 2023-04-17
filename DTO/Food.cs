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
                Ingredient[] ingredients = ingredient.Find(NameF);
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
        private Food[] ConvertDataTableToDTO(DataTable dt)
        {
            Food[] foods = new Food[dt.Rows.Count];
            for (int i = 0; i < foods.Length; i++)
            {
                foods[i] = new Food(dt.Rows[i]);
            }
            return foods;
        }
        public string[] getCategory()
        {
            return BUS.getCategory();
        }
        public Food[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(this);
            Food[] foods = ConvertDataTableToDTO(dt);
            return foods;
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
        public Food[] FindWithCategory(string category)
        {
            DataTable dt = BUS.FindWithCategory(category);
            Food[] foods = ConvertDataTableToDTO(dt);
            return foods;
        }
        public Food[] FindApproximateNameF(string nameF)
        {
            DataTable dt = BUS.FindApproximateNameF(nameF);
            Food[] foods = ConvertDataTableToDTO(dt);
            return foods;
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
