using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ingredient
    {
        private string _name;
        private double _amount;
        private double _inventory;
        private string _nameF;

        public Ingredient() { }
        private Ingredient(DataRow row)
        {
            _name = row["Name"].ToString();
            _nameF = row["NameF"].ToString();
            Amount = double.Parse(row["Amount"].ToString());
            Inventory = double.Parse(row["Inventory"].ToString());
        }

        public Ingredient(string name, double amount, double inventory, string nameF)
        {
            _name = name;
            _amount = amount;
            _inventory = inventory;
            _nameF = nameF;
        }

        public string Name { get => _name; }
        public string NameF { get => _nameF; }
        public double Amount { get => _amount; set => _amount = value; }
        public double Inventory { get => _inventory; set => _inventory = value; }

        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public Ingredient[] Find(string nameF = null)
        {
            DataTable dt = new DataTable();
            if (nameF == null) { dt = CRUD.Instance.FindALl(this); }
            else {
                Ingredient_BUS BUS = new Ingredient_BUS();
                dt = BUS.getIngredientsForFood(nameF);
            }
            Ingredient[] instance = new Ingredient[dt.Rows.Count];
            for (int i = 0; i < instance.Length; i++)
            {
                instance[i] = new Ingredient(dt.Rows[i]);
            }
            return instance;
        }
        public Ingredient Find(string keyName , string keyNameF )
        {
            this._name = keyName; 
            this._nameF = keyNameF;
            DataTable dt = CRUD.Instance.Find(this);
            return new Ingredient(dt.Rows[0]);
        }
        
    }
}
