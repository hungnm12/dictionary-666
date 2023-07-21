using Dapper.Contrib.Extensions;
using H2KT.Core.Constants;
using OfficeOpenXml.Attributes;
using System;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Đối tượng xuất/nhập khẩu
    
    public class BaseImport
    {
        
        /// Index của dòng (bắt đầu từ 1, tương đương với chỉ số dòng excel)
        
        [EpplusIgnore]
        public int RowIndex { get; set; }
    }
}
