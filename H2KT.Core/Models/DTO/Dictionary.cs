using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng dictionary: Bảng chứa thông tin dictionary
    
    public class Dictionary : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid DictionaryId { get; set; }

        
        /// Id người dùng
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string DictionaryName { get; set; }

        
        /// Lần cuối truy cập
        
        public DateTime? LastViewAt { get; set; }
    }
}
