﻿using BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO
{
    public class Ingredient
    {
        private string _name;
        private double _amount;
        private double _inventory;
        private string _nameF;

        public Ingredient() {
            _name = "";
            _amount = 0;
            _inventory = 0;
            _nameF = "";
        }
        private Ingredient(DataRow row)
        {
            _name = row["Name"].ToString();
            _nameF = row["NameF"].ToString();
            Amount = double.Parse(row["Amount"].ToString());
            Inventory = double.Parse(row["Inventory"].ToString());
        }

        public Ingredient(string name, string nameF , double amount, double inventory)
        {
            _name = name;
            _amount = amount;
            _inventory = inventory;
            _nameF = nameF;
        }

        public string Name { get => _name; set => _name = value; }
        public string NameF { get => _nameF;  }
        public double Amount { get => _amount; set => _amount = value; }
        public double Inventory { get => _inventory; set => _inventory = value; }
        public Ingredient[] Ingredients
        {
            get
            {

                return null;
            }
        }

        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public Ingredient[] Find(string nameF = null)
        {
            DataTable dt = new DataTable();
            if (nameF == null) { dt = CRUD.Instance.FindAll(this); }
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
            try
            {
                this._name = keyName;
                this._nameF = keyNameF;
                DataTable dt = CRUD.Instance.Find(this);
                return new Ingredient(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
            
        }
        public void Delete() { 
            CRUD.Instance.Delete(this);
        }
        public double getInventory()
        {
            Ingredient_BUS bus = new Ingredient_BUS();
            return bus.getInventory(Name);
        }
    }
}
