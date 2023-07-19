using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Repository
{
    
    /// Interface quy định các thao tác lấy dữ liệu cơ bản
    
    /// <typeparam name="TEntity">Lớp thực thể</typeparam>
    public interface IBaseRepository<TEntity> where TEntity: class
    {

        #region Tạo kết nối
        
        /// Tạo kết nối
        
        
        IDbConnection CreateConnection();

        
        /// Tạo kết nối bất đồng bộ
        
        
        Task<IDbConnection> CreateConnectionAsync();
        #endregion

        #region Get by id
        
        /// Lấy ra đối tượng thực thể theo khóa chính(id)
        
        /// <param name="entityId">Khóa chính</param>
        /// <param name="dbTransaction">transaction</param>
        /// <returns>Đối tượng thực thể</returns>
        Task<TEntity> Get(Guid entityId, IDbTransaction dbTransaction);

        
        /// Lấy ra đối tượng thực thể theo khóa chính(id)
        
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Đối tượng thực thể</returns>
        Task<TEntity> Get(Guid entityId);
        #endregion

        #region Insert
        
        /// Thêm mới đối tượng thực thể
        
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <param name="dbTransaction">transaction</param> 
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Insert(TEntity entity, IDbTransaction dbTransaction);

        
        /// Thêm mới 1 list đối tượng thực thể
        
        /// <param name="entities">Danh sách bản ghi thêm mới</param>
        /// <param name="dbTransaction">transaction</param> 
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Insert(IEnumerable<TEntity> entities, IDbTransaction dbTransaction);

        
        /// Thêm mới đối tượng thực thể
        
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Insert(TEntity entity);

        
        /// Thêm mới 1 list đối tượng thực thể
        
        /// <param name="entities">Danh sách bản ghi thêm mới</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Insert(IEnumerable<TEntity> entities);

        Task<bool> Insert<T>(T entity, IDbTransaction dbTransaction = null) where T : class;
        Task<bool> Insert<T>(IEnumerable<T> entities, IDbTransaction dbTransaction = null);
        #endregion

        #region Update
        
        /// Cập nhật dữ liệu
        
        /// <param name="entity">Đối tượng cần chỉnh sửa</param>
        /// <param name="dbTransaction">transaction</param> 
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Update(TEntity entity, IDbTransaction dbTransaction);

        
        /// Cập nhật dữ liệu
        
        /// <param name="entities">Danh sách bản ghi cập nhật</param>
        /// <param name="dbTransaction">transaction</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Update(IEnumerable<TEntity> entities, IDbTransaction dbTransaction);

        
        /// Cập nhật dữ liệu
        
        /// <param name="entity">Đối tượng cần chỉnh sửa</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Update(TEntity entity);

        
        /// Cập nhật dữ liệu
        
        /// <param name="entities">Danh sách bản ghi cập nhật</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Update(IEnumerable<TEntity> entities);

        Task<bool> Update(Type type, object param, IDbTransaction transaction = null);

        Task<bool> Update<T>(object param, IDbTransaction transaction = null);

        Task<bool> Update(object param, IDbTransaction transaction = null);
        #endregion

        #region Delete
        
        /// Xóa bản ghi
        
        /// <param name="entity">Bản ghi cần xóa (cần chứa khóa chính)</param>
        /// <param name="dbTransaction">transaction</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Delete(TEntity entity, IDbTransaction dbTransaction);

        
        /// Xóa nhiều bản ghi
        
        /// <param name="entities">danh sách bản ghi</param>
        /// <param name="dbTransaction">transaction</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Delete(IEnumerable<TEntity> entities, IDbTransaction dbTransaction);

        
        /// Xóa bản ghi
        
        /// <param name="entity">Bản ghi cần xóa (cần chứa khóa chính)</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Delete(TEntity entity);

        
        /// Xóa nhiều bản ghi
        
        /// <param name="entities">danh sách bản ghi</param>
        /// <returns>Kết quả thực hiện</returns>
        Task<bool> Delete(IEnumerable<TEntity> entities);

        Task<bool> Delete(Type entityTable, object param, IDbTransaction transaction = null);

        Task<bool> Delete<T>(object param, IDbTransaction transaction = null);

        Task<bool> Delete(object param, IDbTransaction transaction = null);
        #endregion

        #region Check duplicate
        
        /// Hàm kiểm tra trùng lặp dữ liệu
        
        /// <param name="propName">Tên thuộc tính (tương ứng với tên trường trong CSDL)</param>
        /// <param name="value">Giá trị muốn kiểm tra</param>
        /// <returns>true - giá trị bị trùng, false - giá trị không bị trùng</returns>
        Task<bool> CheckDuplicate(string propName, object value);

        
        /// Hàm kiểm tra trùng lặp dữ liệu trước khi update bản ghi
        
        /// <param name="propName">Tên trường dữ liệu</param>
        /// <param name="value">Giá trị cần kiểm tra</param>
        /// <param name="entityId">Đối tượng thực thể</param>
        /// <returns>true - giá trị bị trùng, false - giá trị không bị trùng</returns>
        Task<bool> CheckDuplicateBeforeUpdate(string propName, object value, TEntity entity);
        #endregion

        #region Select
        
        /// Select 1 bản ghi
        
        /// <typeparam name="T"></typeparam>
        /// <param name="paramDict"></param>
        
        Task<object> SelectObject<T>(Dictionary<string, object> paramDict);

        
        /// Select 1 bản ghi
        
        /// <typeparam name="T"></typeparam>
        
        
        Task<object> SelectObject<T>(object param);

        
        /// Select nhiều bản ghi thuộc 1 bảng
        
        /// <typeparam name="T"></typeparam>
        /// <param name="paramDict"></param>
        
        Task<IEnumerable<T>> SelectObjects<T>(Dictionary<string, object> paramDict);

        
        /// Select nhiều bản ghi thuộc 1 bảng
        
        /// <typeparam name="T"></typeparam>
        
        
        Task<IEnumerable<T>> SelectObjects<T>(object param);

        
        /// Select bản ghi thuộc nhiều bảng
        
        /// <param name="tableNames"></param>
        /// <param name="paramDict"></param>
        
        Task<object> SelectManyObjects(string[] tableNames, Dictionary<string, Dictionary<string, object>> paramDict);
        #endregion

    }
}
