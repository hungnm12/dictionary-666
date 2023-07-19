using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý example
    
    public interface IExampleService
    {
        
        /// Thêm 1 example vào từ điển
        
        /// <param name="example"></param>
        
        Task<IServiceResult> AddExample(Example example);

        
        /// Thực hiện cập nhật example
        
        /// <param name="example"></param>
        
        Task<IServiceResult> UpdateExample(Example example);

        
        /// Thực hiện xóa example
        
        /// <param name="exampleId"></param>
        
        Task<IServiceResult> DeleteExample(Guid exampleId);

        
        /// Lấy dữ liệu example
        
        /// <param name="exampleId"></param>
        
        Task<IServiceResult> GetExample(Guid exampleId);

        
        /// Tìm kiếm example
Task<IServiceResult> SearchExample(SearchExampleParam param);
    }
}
