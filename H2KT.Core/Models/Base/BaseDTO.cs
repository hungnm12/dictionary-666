using System;
using System.Linq;

namespace H2KT.Core.Models
{
    
    /// Lớp cơ sở cho DTO
    
    public class BaseDTO : BaseModel
    {
        
        /// Thời điểm tạo
        
        public DateTime? CreatedDate { get; set; }

        
        /// Thời điểm sửa
        
        public DateTime? ModifiedDate { get; set; }

        
        /// Hàm lấy ra thuộc tính khóa chính
        
        /// <returns>Property khóa chính</returns>
        public System.Reflection.PropertyInfo GetPrimaryKey()
        {
            return this.GetType().GetProperties().FirstOrDefault(x => x.GetCustomAttributes(false).Any(x => x is Dapper.Contrib.Extensions.KeyAttribute));
        }
    }
}
