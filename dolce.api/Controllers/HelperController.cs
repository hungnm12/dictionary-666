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
    
    /// Lớp controller cung cấp api helper
    
    public class HelperController : BaseApiController
    {
        #region Fields
        private readonly IExternalApiService _service;
        #endregion

        #region Constructors

        public HelperController(INhom2ServiceCollection serviceCollection,
            IExternalApiService service) : base(serviceCollection)
        {
            _service = service;
        }

        #endregion

        #region Methods
        
        /// Lấy dữ liệu wordsapi
        
        /// <param name="word"></param>
        
        [HttpGet("wordsapi")]
        public async Task<IServiceResult> GetWordsapiResult(string word)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetWordsapiResult(word);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy dữ liệu freedictionaryapi
        
        /// <param name="word"></param>
        
        [HttpGet("freedictionaryapi")]
        public async Task<IServiceResult> GetFreeDictionaryApiResult(string word)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetFreeDictionaryApiResult(word);
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
