using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng dictionary: Bảng chứa thông tin dictionary
    
    [System.ComponentModel.DataAnnotations.Schema.Table("dictionary")]
    public class dictionary : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid dictionary_id { get; set; }

        
        /// Id người dùng
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string dictionary_name { get; set; }

        
        /// Lần cuối truy cập
        
        public DateTime? last_view_at { get; set; }
    }
}
