using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using System;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Repository
{

    public interface IUserRepository: IBaseRepository<user>
    {
        
        /// Khởi tạo dữ liệu khi tài khoản được kích hoạt
        
        /// <param name="userId"></param>
        
        Task<bool> CreateActivatedAccountData(string userId);
    }
}
