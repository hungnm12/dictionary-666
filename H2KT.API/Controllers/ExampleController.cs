using H2KT.Core.Constants;
using H2KT.Core.Enums;
using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace H2KT.Api.Controllers
{
    
    /// Lớp controller cung cấp api liên quan đến example
    
    public class ExampleController : BaseApiController
    {
        #region Fields
        private readonly IExampleService _service;
        #endregion

        #region Constructors

        public ExampleController(INhom2ServiceCollection serviceCollection, IExampleService service) : base(serviceCollection)
        {
            _service = service;
        }

        #endregion

        #region Methods
        
        /// Thực hiện thêm 1 example
        
        /// <param name="example"></param>
        
        [HttpPost("add_example")]
        public async Task<IServiceResult> AddExample([FromBody] Example example)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.AddExample(example);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện cập nhật example
[HttpPut("update_example")]
        public async Task<IServiceResult> UpdateConcept([FromBody] Example example)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.UpdateExample(example);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện xóa example
        
        /// <param name="exampleId"></param>
        
        [HttpDelete("delete_example")]
        public async Task<IServiceResult> DeleteExample([FromQuery] Guid exampleId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.DeleteExample(exampleId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy dữ liệu example
[HttpGet("get_example")]
        public async Task<IServiceResult> GetConcept([FromQuery] Guid exampleId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetExample(exampleId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Tìm kiếm example
[HttpPost("search_example")]
        public async Task<IServiceResult> SearchExample([FromBody] SearchExampleParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.SearchExample(param);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }


        #endregion
    }
}
