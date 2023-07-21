using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace H2KT.Api.Controllers
{
    public class AuditLogController : BaseApiController
    {
        #region Fields
        private readonly IAuditLogService _service;
        #endregion

        #region Constructor
        public AuditLogController(INhom2ServiceCollection serviceCollection, IAuditLogService service) : base(serviceCollection)
        {
            _service = service;
        }
        #endregion
        /// Lấy lịch sử truy cập của người dùng
        [HttpGet("get_logs")]
        public async Task<IServiceResult> GetLogs([FromQuery]string searchFilter, 
            int? pageIndex, int? pageSize, string dateFrom, string dateTo)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetLogs(searchFilter, pageIndex, pageSize, dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        /// Lưu lịch sử truy cập của người dùng
        [HttpPost("save_log")]
        public async Task<IServiceResult> SaveLog([FromBody] AuditLog param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.SaveLog(param);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
    }
}
