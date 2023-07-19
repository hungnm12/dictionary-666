using System.Collections.Generic;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Kết quả lọc/ phân trang dữ liệu
    
    /// <typeparam name="TModel">Đối tượng thực thể</typeparam>
    public class FilterResult<TModel>
    {
        #region Properties

        
        /// Tổng số bản ghi trả về
        
        public int? TotalRecords { get; set; }

        
        /// Tổng số trang
        
        public int? TotalPages { get; set; }

        
        /// Danh sách bản ghi trả về
        
        public IEnumerable<TModel> Data { get; set; }

        #endregion
    }
}
