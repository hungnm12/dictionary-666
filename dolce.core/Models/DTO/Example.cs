using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng example: Bảng chứa thông tin example
    
    public class Example : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid ExampleId { get; set; }

        
        /// Id dictionary
        
        public Guid? DictionaryId { get; set; }

        
        /// Id tone
        
        public Guid? ToneId { get; set; }

        
        /// Id register
        
        public Guid? RegisterId { get; set; }

        
        /// Id dialect
        
        public Guid? DialectId { get; set; }

        
        /// Id mode
        
        public Guid? ModeId { get; set; }

        
        /// Id nuance
        
        public Guid? NuanceId { get; set; }

        
        /// Ghi chú
        
        public string Note { get; set; }

        
        /// Nội dung ví dụ
        
        public string Detail { get; set; }

        
        /// Nội dung ví dụ dạng html
        
        public string DetailHtml { get; set; }

        #region Custom properties

        
        /// Danh sách liên kết example-concept
        
        public List<ViewExampleRelationship> ListExampleRelationship { get; set; }

        public string ToneName { get; set; }
        public string ModeName { get; set; }
        public string RegisterName { get; set; }
        public string NuanceName { get; set; }
        public string DialectName { get; set; }
        #endregion
    }
}
