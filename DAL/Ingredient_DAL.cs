using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class Ingredient_DAL : ICRUD
    {
        public void Delete(dynamic obj)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery($"delete Ingredient where NameF = N'{obj.NameF}' and Name = N'{obj.Name}'");
            }
            catch (Exception err) { throw err; }
        }

        public DataTable Find(dynamic key = null)
        {
            try
            {
                DataTable dt = new DataTable();
                if (key == null) { dt = DataProvider.Instance.ExecuteQuery("select * from Ingredient"); }
                else { dt = DataProvider.Instance.ExecuteQuery($"select * from Ingredient where NameF = N'{key.NameF}' and Name = N'{key.Name}'"); }
                return dt;
            }
            catch(Exception err) { throw err; }
            
        }
        public DataTable getIngredientsForFood(string key)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery($"select * from Ingredient where NameF = N'{key}'");
            }
            catch(Exception err) { throw err; }
        }
        private void Update(dynamic obj)
        {
            string query2 = $"update Ingredient set Inventory = {obj.Inventory.ToString()}  where Name = N'{obj.Name}'";
            string query = $"update Ingredient set Inventory = {obj.Inventory.ToString()} , Amount = {obj.Amount}  where Name = N'{obj.Name}' and NameF = N'{obj.NameF}'";
            DataProvider.Instance.ExecuteNonQuery(query);
            DataProvider.Instance.ExecuteNonQuery(query2);
        }
        
        public void Save(dynamic obj) //Hàm Này hơi xấu tý . Sửa sau ^^
        {
            try
            {
                //Kiểm tra "Muối" có chưa
                DataTable dt = DataProvider.Instance.ExecuteQuery($"select Inventory from Ingredient where  Name = N'{obj.Name}'");
                if (dt.Rows.Count > 0) // Có rồi
                {
                    //Kiểm tra "Muối" + "Gà sốt tiêu xanh" có chưa
                    DataTable dt2 = DataProvider.Instance.ExecuteQuery($"select Inventory from Ingredient where  Name = N'{obj.Name}' and NameF = N'{obj.NameF}'");
                    if (dt2.Rows.Count > 0)
                    {
                        Update(obj);
                    }
                    else
                    {
                        // Insert Ingredient với tồn kho là Inventory của muối trong DB
                        string query = $"insert into Ingredient(Name , NameF , Amount , Inventory) " +
                            $"values(N'{obj.Name}' , N'{obj.NameF}' , {obj.Amount} , " +
                            $"{double.Parse(dt.Rows[0]["Inventory"].ToString())})";
                        DataProvider.Instance.ExecuteNonQuery(query);
                    }
                       
                }
                else // Chưa có
                {
                    
                    string query = $"insert into Ingredient(Name , NameF , Amount , Inventory) values(N'{obj.Name}' , N'{obj.NameF}' , {obj.Amount} , {obj.Inventory})";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }

            }
            catch(Exception err) { throw err; }
        }
        public object getInventory(string Name)
        {
            return DataProvider.Instance.ExecutesScalar($"select Inventory from Ingredient where  Name = N'{Name}'");
        }
        public DataTable groupByName()
        {
            return DataProvider.Instance.ExecuteQuery($"select Name , Inventory from Ingredient group by Name , Inventory");
        }
    }
}
