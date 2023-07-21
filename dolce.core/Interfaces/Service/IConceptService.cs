using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý concept
    
    public interface IConceptService
    {
        
        /// Lấy danh sách concept trong từ điển
        Task<IServiceResult> GetListConcept(string dictionaryId);

        
        /// Thêm 1 concept vào từ điển
        Task<IServiceResult> AddConcept(Concept concept);

        
        /// Thực hiện cập nhật tên, mô tả của concept
        Task<IServiceResult> UpdateConcept(Concept concept);

        
        /// Thực hiện xóa concept

        Task<IServiceResult> DeleteConcept(string conceptId, bool? isForced);

        
        /// Lấy dữ liệu concept và các example liên kết với concept đó
        Task<IServiceResult> GetConcept(string conceptId);

        
        /// Lấy danh sách concept trong từ điển mà khớp với xâu tìm kiếm của người dùng
        
        
        /// <param name="isSearchSoundex"></param>
        
        Task<IServiceResult> SearchConcept(string searchKey, string dictionaryId, bool? isSearchSoundex);

        
        /// Lấy ra mối quan hệ liên kết giữa concept con và concept cha.

        Task<IServiceResult> GetConceptRelationship(string conceptId, string parentId);

        
        /// Thực hiện cập nhật (hoặc tạo mới nếu chưa có) liên kết giữa 2 concept
        Task<IServiceResult> UpdateConceptRelationship(UpdateConceptRelationshipParam param);

        
        /// Thực hiện lấy danh sách gợi ý concept từ những từ khóa người dùng cung cấp.

        Task<IServiceResult> GetListRecommendConcept(List<string> keywords, Guid? dictionaryId);

        #region Tree service
        
        /// Lấy dữ liệu tree của concept
        Task<IServiceResult> GetTree(Guid conceptId);

        
        /// Lấy dữ liệu tree: các concept cha của 1 concept
        Task<IServiceResult> GetConceptParents(Guid conceptId);

        
        /// Lấy dữ liệu tree: các concept con của 1 concept
        Task<IServiceResult> GetConceptChildren(Guid conceptId);

        
        /// Lấy dữ liệu tree: danh sách example liên kết với 1 concept theo loại mối quan hệ
        Task<IServiceResult> GetLinkedExampleByRelationshipType(Guid conceptId, Guid exampleLinkId);
        #endregion


    }
}
