using BUS;
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
        public Ingredient(string name , string namef)
        {
            _name = name;
            _nameF = namef;
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
        public string Name { get => _name;}
        public string NameF { get => _nameF;  }
        public double Amount { get => _amount; set => _amount = value; }
        public double Inventory { get => _inventory; set => _inventory = value; }
        private static Ingredient[] ConvertDataTableToDTO(DataTable dt)
        {
            Ingredient[] BillInfos = new Ingredient[dt.Rows.Count];
            for (int i = 0; i < BillInfos.Length; i++)
            {
                BillInfos[i] = new Ingredient(dt.Rows[i]);
            }
            return BillInfos;
        }
        public void Save()
        {
            CRUD.Instance.Save(this);
        }
        public static Ingredient Find(string keyName , string keyNameF )
        {
            try
            {

                DataTable dt = CRUD.Instance.Find(new Ingredient(keyName,keyNameF));
                return new Ingredient(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }
            
        }
        public static Ingredient[] getElementByNameF(string nameF)
        {
            Ingredient_BUS BUS = new Ingredient_BUS();
            DataTable dt =  BUS.getIngredientsForFood(nameF);
            return ConvertDataTableToDTO(dt);
        }


        public Ingredient getElementById()
        {
            try
            {
                DataTable dt = CRUD.Instance.Find(this);
                return new Ingredient(dt.Rows[0]);
            }
            catch (IndexOutOfRangeException) { return null; }

        }
        public void Delete() { 
            CRUD.Instance.Delete(this);
        }
        public static double getInventory(string Name)
        {
            Ingredient_BUS bus = new Ingredient_BUS();
            return bus.getInventory(Name);
        }
        public static Ingredient[] Find()
        {
            DataTable dt = CRUD.Instance.FindAll(new Ingredient());
            return ConvertDataTableToDTO(dt);
        }
    }
}
