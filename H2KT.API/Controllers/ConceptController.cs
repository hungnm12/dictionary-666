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
    
    /// Lớp controller cung cấp api liên quan đến concept
    
    public class ConceptController : BaseApiController
    {
        #region Fields
        private readonly IConceptService _service;
        #endregion

        #region Constructors

        public ConceptController(INhom2ServiceCollection serviceCollection, IConceptService service) : base(serviceCollection)
        {
            _service = service;
        }

        #endregion

        #region Methods
        
        /// Lấy danh sách concept trong từ điển
        
        
        [HttpGet("get_list_concept")]
        public async Task<IServiceResult> GetListConcept([FromQuery] string dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetListConcept(dictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện thêm 1 concept vào từ điển
[HttpPost("add_concept")]
        public async Task<IServiceResult> AddConcept([FromBody] Concept concept)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.AddConcept(concept);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        
        /// Thực hiện cập nhật tên, mô tả của concept
[HttpPut("update_concept")]
        public async Task<IServiceResult> UpdateConcept([FromBody] Concept concept)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.UpdateConcept(concept);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện xóa concept

        [HttpDelete("delete_concept")]
        public async Task<IServiceResult> DeleteConcept([FromQuery] string conceptId, bool? isForced)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.DeleteConcept(conceptId, isForced);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy dữ liệu concept và các example liên kết với concept đó
[HttpGet("get_concept")]
        public async Task<IServiceResult> GetConcept([FromQuery] string conceptId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetConcept(conceptId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy danh sách concept trong từ điển mà khớp với xâu tìm kiếm của người dùng
[HttpGet("search_concept")]
        public async Task<IServiceResult> SearchConcept([FromQuery] string searchKey, string dictionaryId, bool? isSearchSoundex)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.SearchConcept(searchKey, dictionaryId, isSearchSoundex);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy ra mối quan hệ liên kết giữa concept con và concept cha.

        [HttpGet("get_concept_relationship")]
        public async Task<IServiceResult> GetConceptRelationship([FromQuery] string conceptId, string parentId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetConceptRelationship(conceptId, parentId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện cập nhật (hoặc tạo mới nếu chưa có) liên kết giữa 2 concept
[HttpPut("update_concept_relationship")]
        public async Task<IServiceResult> UpdateConceptRelationship([FromBody] UpdateConceptRelationshipParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.UpdateConceptRelationship(param);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }


        
        /// Thực hiện lấy danh sách gợi ý concept từ những từ khóa người dùng cung cấp

        [HttpGet("get_list_recommend_concept")]
        public async Task<IServiceResult> GetListRecommendConcept([FromBody] List<string> keywords, Guid? dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetListRecommendConcept(keywords, dictionaryId);
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
