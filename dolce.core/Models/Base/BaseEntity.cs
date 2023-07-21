using System;

namespace H2KT.Core.Models
{
    
    /// Lớp cơ sở cho các thực thể
    
    public class BaseEntity : BaseModel
    {
        #region Properties

        
        /// Thời điểm tạo
        
        public DateTime? created_date { get; set; }

        
        /// Thời điểm cập nhật
        
        public DateTime? modified_date { get; set; }

        #endregion
    }
}
