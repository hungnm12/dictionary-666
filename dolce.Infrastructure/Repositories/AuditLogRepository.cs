using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class AuditLogRepository : BaseRepository<audit_log>, IAuditLogRepository
    {
        #region Constructors
        public AuditLogRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods

        
        /// Lấy danh sách lịch sử truy cập (lọc và phân trang)
        
        /// <param name="searchFilter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>


        public async Task<FilterResult<AuditLog>> GetLogsByFilter(string userId, string searchFilter, 
        int? pageIndex, int? pageSize, DateTime? dateFrom, DateTime? dateTo)
        {
            // Thiết lập các tham số
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            searchFilter = '%' + searchFilter + '%';
            parameters.Add("@SearchFilter", searchFilter);
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@DateFrom", dateFrom);
            parameters.Add("@DateTo", dateTo);

            // Câu truy vấn để lấy kết quả theo trang
            var logsQuery = @"
                SELECT * FROM audit_log 
                WHERE reference LIKE @SearchFilter 
                AND created_date >= @DateFrom 
                AND created_date <= @DateTo
                LIMIT @Offset, @PageSize;
            ";

            // Câu truy vấn để đếm số kết quả trả về
            var countQuery = @"
                SELECT COUNT(*) FROM audit_log 
                WHERE reference LIKE @SearchFilter 
                AND created_date >= @DateFrom 
                AND created_date <= @DateTo;
            ";

            // Kết quả đầu ra
            var result = new FilterResult<AuditLog>();

            using (var connection = await this.CreateConnectionAsync())
            {
                // Lấy tổng số kết quả
                result.TotalRecords = await connection.ExecuteScalarAsync<int>(countQuery, parameters);

                // Tính toán số trang
                result.TotalPages = (int)Math.Ceiling((double)result.TotalRecords / pageSize.GetValueOrDefault());

                // Tính toán offset
                var offset = (pageIndex.GetValueOrDefault() - 1) * pageSize.GetValueOrDefault();
                parameters.Add("@Offset", offset);

                // Lấy kết quả theo trang
                var res = await connection.QueryAsync<audit_log>(logsQuery, parameters);

                // Trả về kết quả filter
                result.Data = res != null ? this.ServiceCollection.Mapper.Map<IEnumerable<AuditLog>>(res) : null;
            }

            return result;
        }

        #endregion

    }
}
