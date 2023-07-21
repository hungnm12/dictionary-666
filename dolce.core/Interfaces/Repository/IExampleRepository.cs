using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.Param;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Repository
{

    public interface IExampleRepository: IBaseRepository<example>
    {
        
        /// Tìm kiếm example
Task<List<Example>> SearchExample(SearchExampleParam param);
    }
}
