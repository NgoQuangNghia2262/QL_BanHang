﻿using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CRUD : ICRUD
    {
        private static CRUD instance;
        public static CRUD Instance
        {
            get { if (instance == null) { instance = new CRUD(); } return CRUD.instance; }
            private set { CRUD.instance = value; }
        }
        private CRUD() { }
        public void Delete(object obj)
        {
            string objType = obj.GetType().Name;
            switch (objType)
            {
                case "Table": {
                        CRUDTable_BUS BUS = new CRUDTable_BUS();
                        BUS.Delete(obj);
                        break; }
                case "Account": {
                        CRUDAccount_BUS BUS = new CRUDAccount_BUS();
                        BUS.Delete(obj); 
                        break; }
                case "Food": {
                        CRUDFood_BUS BUS = new CRUDFood_BUS();
                        BUS.Delete(obj);
                        break; }
                case "Ingredient":
                    {
                        CRUDIngredient_BUS BUS = new CRUDIngredient_BUS();
                        BUS.Delete(obj);
                        break;
                    }
                case "Bill_Info":
                    {
                        CRUDBill_Info_BUS BUS = new CRUDBill_Info_BUS();
                        BUS.Delete(obj);
                        break;
                    }
                case "Bill":
                    {
                        CRUDBill_BUS BUS = new CRUDBill_BUS();
                        BUS.Delete(obj);
                        break;
                    }
                default: { throw new Exception($"Chưa thiết lập case {objType} tại lớp CRUD"); }
                    
            }
        }

        //
        // Summary:
        //     1.Phương thức nhận 1 obj -> trả về 1 bảng dữ liệu
        //     2.Kiểm tra kiểu dữ liệu (nếu obj đó có kiểu dữ liệu là table thì trả về TẤT CẢ DỮ LIỆU của bảng table trong SQL)
        //     3.Rồi trả về Bảng tương ứng 
        //     VD : obj là Table -> trả về 1 DataTable chứa thông tin Table
        //
        // Type parameters:
        //     Đối tượng trong lớp DTO
        //    
        public DataTable FindALl(object obj)
        {
            string objType = obj.GetType().Name;
            DataTable dt = new DataTable();
            switch (objType)
            {
                case "Table":
                    {
                        CRUDTable_BUS instance = new CRUDTable_BUS();
                        dt = instance.Find();
                        break;
                    }
                case "Ingredient":
                    {
                        CRUDIngredient_BUS instance = new CRUDIngredient_BUS();
                        dt = instance.Find();
                        break;
                    }
                case "Bill_Info":
                    {
                        CRUDBill_Info_BUS instance = new CRUDBill_Info_BUS();
                        dt = instance.Find();
                        break;
                    }
                case "Bill":
                    {
                        CRUDBill_BUS instance = new CRUDBill_BUS();
                        dt = instance.Find();
                        break;
                    }
                case "Account": {
                        CRUDTable_BUS instance = new CRUDTable_BUS();
                        dt = instance.Find();
                        break; 
                    }
                case "Food": {
                        CRUDTable_BUS instance = new CRUDTable_BUS();
                        dt = instance.Find();
                        break; 
                    }
                default: { throw new Exception($"Chưa thiết lập case {objType} tại lớp CRUD"); }

            }
            return dt;
        }

        //
        // Summary:
        //     1.Phương thức nhận 1 obj -> trả về các DỮ LIỆU CÓ ĐIỀU KIỆN
        //     VD : lấy danh sách bill có id = 1 , lấy danh sách account có username = "admin"
        //     2.Kiểm tra kiểu dữ liệu
        //     3.Rồi trả về dữ liệu tương ứng 
        //     VD : obj là Table -> trả về 1 DataTable chứa  thông tin 1 Table 
        //
        // Type parameters:
        //     Đối tượng trong lớp DTO
        //    
        public DataTable Find(object obj)
        {
            string objType = obj.GetType().Name;
            DataTable dt = new DataTable();
            switch (objType)
            {
                case "Table": {
                        CRUDTable_BUS instance = new CRUDTable_BUS();
                        dt = instance.Find(obj);
                        break; 
                    }
                case "Account": {
                        CRUDTable_BUS instance = new CRUDTable_BUS();
                        dt = instance.Find(obj);
                        break; }
                case "Food": {
                        CRUDFood_BUS instance = new CRUDFood_BUS();
                        dt = instance.Find(obj);
                        break; }
                case "Bill":
                    {
                        CRUDBill_BUS instance = new CRUDBill_BUS();
                        dt = instance.Find(obj);
                        break;
                    }
                case "Ingredient":
                    {
                        CRUDIngredient_BUS instance = new CRUDIngredient_BUS();
                        dt = instance.Find(obj);
                        break;
                    }
                case "Bill_Info": {
                        CRUDBill_Info_BUS instance = new CRUDBill_Info_BUS();
                        dt = instance.Find(obj);
                        break;
                    }
                default: { throw new Exception($"Chưa thiết lập case {objType} tại lớp CRUD"); }

            }
            return dt;
        }

        public void Save(object obj)
        {
            string objType = obj.GetType().Name;
            switch (objType)
            {
                case "Table": { break; }
                case "Bill_Info": {
                        Bill_Info_DAL instance = new Bill_Info_DAL();
                        instance.Save(obj);
                        break; }
                case "Ingredient":
                    {
                        Ingredient_DAL instance = new Ingredient_DAL();
                        instance.Save(obj);
                        break;
                    }
                case "Bill":
                    {
                        Bill_DAL instance = new Bill_DAL();
                        instance.Save(obj);
                        break;
                    }
                case "Account": { break; }
                case "Food": { break; }
                default: { throw new Exception($"Chưa thiết lập case {objType} tại lớp CRUD"); }
                    
            }
        }
        public DataTable Find()
        {
            throw new NotImplementedException();
        }
    }
}
