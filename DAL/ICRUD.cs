using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface  ICRUD
    {
        //
        // Summary:
        //     1.Phương thức nhận 1 obj -> trả về 1 bảng dữ liệu
        //     2.Kiểm tra user có truyền parameters 
        //          2.1 Nếu parameters được truyền vào thì truy xuất dữ liệu với 1 điều kiện
        //          2.2 nếu không truyền parameters thì lấy tất cả dữ liệu trong DataBase
        //     3.Rồi trả về Bảng tương ứng 
        //
        // Type parameters:
        //     Đối tượng trong lớp DTO
        //    
        DataTable Find(dynamic key);

        //
        // Summary:
        //     1.Phương thức nhận 1 obj -> update DataBase
        //     2.Kiểm tra obj đã có trong DataBase chưa
        //          2.1  True : Sửa 
        //          2.2 False : Thêm
        //
        // Type parameters:
        //     Đối tượng trong lớp DTO
        //    
        void Save(dynamic obj);
        void Delete(dynamic obj);   
        
    }
}
