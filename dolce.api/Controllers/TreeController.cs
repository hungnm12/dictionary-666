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
    
    /// Lớp controller cung cấp api liên quan đến view tree
    
    public class TreeController : BaseApiController
    {
        #region Fields
        private readonly IConceptService _conceptService;
        #endregion

        #region Constructors

        public TreeController(INhom2ServiceCollection serviceCollection, 
            IConceptService conceptService) : base(serviceCollection)
        {
            _conceptService = conceptService;
        }

        #endregion

        #region Methods
        
        /// Lấy dữ liệu tree của concept
[HttpGet("get_tree")]
        public async Task<IServiceResult> GetTree(Guid conceptId)
        {
            var res = new ServiceResult();
            try
            {
                return await _conceptService.GetTree(conceptId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy dữ liệu tree: các concept cha của 1 concept
[HttpGet("get_concept_parents")]
        public async Task<IServiceResult> GetConceptParents(Guid conceptId)
        {
            var res = new ServiceResult();
            try
            {
                return await _conceptService.GetConceptParents(conceptId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }


        
        /// Lấy dữ liệu tree: các concept con của 1 concept
[HttpGet("get_concept_children")]
        public async Task<IServiceResult> GetConceptChildren(Guid conceptId)
        {
            var res = new ServiceResult();
            try
            {
                return await _conceptService.GetConceptChildren(conceptId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy dữ liệu tree: danh sách example liên kết với 1 concept theo loại mối quan hệ
[HttpGet("get_linked_example_by_relationship_type")]
        public async Task<IServiceResult> GetLinkedExampleByRelationshipType(Guid conceptId, Guid exampleLinkId)
        {
            var res = new ServiceResult();
            try
            {
                return await _conceptService.GetLinkedExampleByRelationshipType(conceptId, exampleLinkId);
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
