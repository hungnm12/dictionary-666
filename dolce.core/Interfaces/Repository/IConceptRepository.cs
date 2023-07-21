using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Repository
{

    public interface IConceptRepository: IBaseRepository<concept>
    {
        
        /// Thực hiện lấy danh sách concept trong từ điển mà khớp với xâu tìm kiếm của người dùng
        
        
        /// <param name="isSearchSoundex"></param>
        
        Task<List<Concept>> SearchConcept(string searchKey, string dictionaryId, bool? isSearchSoundex);
    }
}
