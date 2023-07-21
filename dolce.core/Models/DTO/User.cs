using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng user: Bảng thông tin user
    
    public class User : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid UserId { get; set; }

        
        /// Tên đăng nhập
        
        public string UserName { get; set; }

        
        /// Mật khẩu
        
        public string Password { get; set; }

        
        /// Email
        
        public string Email { get; set; }

        
        /// Tên đầy đủ
        
        public string FullName { get; set; }

        
        /// Tên hiển thị
        
        public string DisplayName { get; set; }

        
        /// Vị trí, công việc
        
        public string Position { get; set; }

        
        /// Ngày sinh
        
        public DateTime? Birthday { get; set; }

        
        /// Link avatar
        
        public string Avatar { get; set; }

        
        /// Trạng thái
        
        public int? Status { get; set; }

        #region Custom
        
        /// Id dictionary đang thao tác
        
        public Guid? DictionaryId { get; set; }

        #endregion
    }
}
