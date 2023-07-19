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
    
    /// Lớp controller cung cấp api lấy cấu hình: concept link, example link, tone, mode...
    
    public class UserConfigController : BaseApiController
    {
        #region Fields
        private readonly IUserConfigService _service;
        #endregion

        #region Constructors

        public UserConfigController(INhom2ServiceCollection serviceCollection, IUserConfigService service) : base(serviceCollection)
        {
            _service = service;
        }

        #endregion

        #region Methods
        
        /// Lấy danh sách concept link
        
        
        [HttpGet("get_list_concept_link")]
        public async Task<IServiceResult> GetListConceptLink()
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetListConceptLink();
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy danh sách example link
        
        
        [HttpGet("get_list_example_link")]
        public async Task<IServiceResult> GetListExampleLink()
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetListExampleLink();
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy danh sách example attribute
        
        
        [HttpGet("get_list_example_attribute")]
        public async Task<IServiceResult> GetListExampleAttribute()
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetListExampleAttribute();
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
