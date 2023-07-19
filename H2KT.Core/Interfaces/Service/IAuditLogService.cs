using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý dữ liệu log
    
    public interface IAuditLogService
    {
        
        /// Lấy lịch sử truy cập của người dùng
        
        /// <param name="searchFilter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="dateForm"></param>
        /// <param name="dateTo"></param>
        
        Task<IServiceResult> GetLogs(string searchFilter, int? pageIndex, int? pageSize, string dateForm, string dateTo);

        
        /// Lưu lịch sử truy cập của người dùng
Task<IServiceResult> SaveLog(AuditLog param);
    }
}
