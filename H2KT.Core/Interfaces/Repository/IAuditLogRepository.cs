using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.ServerObject;
using System;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Repository
{

    public interface IAuditLogRepository: IBaseRepository<audit_log>
    {
        
        /// Lấy danh sách lịch sử truy cập (lọc và phân trang)
        
        /// <param name="searchFilter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        
        Task<FilterResult<AuditLog>> GetLogsByFilter(string userId, string searchFilter, 
            int? pageIndex, int? pageSize, DateTime? dateFrom, DateTime? dateTo);
    }
}
