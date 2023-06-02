using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CRUD 
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
            BUS.ICRUD BUS;
            string objType = obj.GetType().Name;
            switch (objType)
            {
                case "Table": {
                        BUS = new CRUDTable_BUS();
                        break; }
                case "Account": {
                        BUS = new CRUDAccount_BUS();
                        break; }
                case "Food": {
                        BUS = new CRUDFood_BUS();
                        break; }
                case "Ingredient":
                    {
                        BUS = new CRUDIngredient_BUS();
                        break;
                    }
                case "Bill_Info":
                    {
                        BUS = new CRUDBill_Info_BUS();
                        break;
                    }
                case "Bill":
                    {
                        BUS = new CRUDBill_BUS();
                        break;
                    }
                case "ImportingInvoices":
                    {
                        BUS = new CRUDImportingInvoices_BUS();
                        break;
                    }
                case "CRUDImportingInvoices_Info":
                    {
                        BUS = new CRUDImportingInvoices_Info_BUS();
                        break;
                    }
                default: { throw new ArgumentOutOfRangeException(nameof(objType) , $"Chưa thiết lập case {objType} tại lớp CRUD"); }
            }
            BUS.Delete(obj);
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
        public DataTable FindAll(object obj)
        {
            BUS.ICRUD instance;
            string objType = obj.GetType().Name;
            switch (objType)
            {
                case "Table":
                    {
                        instance = new CRUDTable_BUS();
                        break;
                    }
                case "Ingredient":
                    {
                        instance = new CRUDIngredient_BUS();
                        break;
                    }
                case "Bill_Info":
                    {
                        instance = new CRUDBill_Info_BUS();
                        break;
                    }
                case "Bill":
                    {
                        instance = new CRUDBill_BUS();
                        break;
                    }
                case "Account": {
                        instance = new CRUDAccount_BUS();
                        break; 
                    }
                case "Food": {
                        instance = new CRUDFood_BUS();
                        break; 
                    }
                case "ImportingInvoices":
                    {
                        instance = new CRUDImportingInvoices_BUS();
                        break;
                    }
                case "ImportingInvoices_Info":
                    {
                        instance = new CRUDImportingInvoices_Info_BUS();
                        break;
                    }
                default: { throw new ArgumentOutOfRangeException(nameof(objType), $"Chưa thiết lập case {objType} tại lớp CRUD"); }
            }
            return instance.Find();
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
                        CRUDAccount_BUS instance = new CRUDAccount_BUS();
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
                case "ImportingInvoices": {
                        CRUDImportingInvoices_BUS instance = new CRUDImportingInvoices_BUS();
                        dt = instance.Find(obj);
                        break;
                    }
                case "ImportingInvoices_Info":
                    {
                        CRUDImportingInvoices_Info_BUS instance = new CRUDImportingInvoices_Info_BUS();
                        dt = instance.Find(obj);
                        break;
                    }
                default: { throw new Exception($"Chưa thiết lập case {objType} tại lớp CRUD"); }

            }
            return dt;
        }

        public void Save(object obj)
        {
            BUS.ICRUD instance;
            string objType = obj.GetType().Name;
            switch (objType)
            {
                case "ImportingInvoices":
                    {
                        instance = new CRUDImportingInvoices_BUS();
                        break;
                    }
                case "ImportingInvoices_Info":
                    {
                        instance = new CRUDImportingInvoices_Info_BUS();
                        break;
                    }
                case "Table": 
                    {
                        instance = new CRUDTable_BUS();
                        break; 
                    }
                case "Bill_Info": 
                    {
                        instance = new CRUDBill_Info_BUS();
                        break; 
                    }
                case "Ingredient":
                    {
                        instance = new CRUDIngredient_BUS();
                        break;
                    }
                case "Bill":
                    {
                        instance = new CRUDBill_BUS();
                        break;
                    }
                case "Account":
                    {
                        instance = new CRUDAccount_BUS();
                        break; 
                    }
                case "Food": 
                    {
                        instance = new CRUDFood_BUS();
                        break;
                    }
                default: { throw new ArgumentOutOfRangeException(nameof(objType), $"Chưa thiết lập case {objType} tại lớp CRUD"); }
                
            }
            instance.Save(obj);
        }
        
    }
}
