using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Interface quy định các service xử lý nghiệp vụ khi thao tác dữ liệu
    
    /// <typeparam name="TEntity">Lớp thực thể</typeparam>
    public interface IBaseService<TEntity> where TEntity : class
    {
        
        /// Service xử lý khi lấy dữ liệu theo Khóa chính (id)
        
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        Task<ServiceResult> GetById(Guid entityId);

        
        /// Service xử lý khi thêm dữ liệu
        
        /// <param name="entity">Đối tượng muốn thêm</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        Task<ServiceResult> Insert(TEntity entity);

        
        /// Service xử lý khi cập nhật/chỉnh sửa dữ liệu
        
        /// <param name="entityId">Khóa chính</param>
        /// <param name="entity">Đối tượng muốn cập nhật</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        Task<ServiceResult> Update(Guid entityId, TEntity entity);

        
        /// Service xử lý khi xóa dữ liệu theo Khóa chính (id)
        
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng ServiceResult chứa kết quả thực hiện</returns>
        Task<ServiceResult> Delete(Guid entityId);
    }
}
