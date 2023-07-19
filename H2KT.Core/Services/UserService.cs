using H2KT.Core.Constants;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using User = H2KT.Core.Models.DTO.User;

namespace H2KT.Core.Services
{
    
    /// Serivce xử lý user
    
    public class UserService : BaseService, IUserService
    {
        #region Field

        private readonly IUserRepository _repository;
        private readonly StorageUtil _storage;
        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository,
            INhom2ServiceCollection serviceCollection,
            StorageUtil storage) : base(serviceCollection)
        {
            _repository = userRepository;
            _storage = storage;
        }

        #endregion

        #region Method

        
        /// Thay đổi mật khẩu
        
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        
        public async Task<IServiceResult> UpdatePassword(string oldPassword, string newPassword)
        {
            var res = new ServiceResult();

            // Kiểm tra thông tin đăng nhập
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                return res.OnError(ErrorCode.Err9000, ErrorMessage.Err9000);
            }

            var userId = this.ServiceCollection.AuthUtil.GetCurrentUserId();
            var user = await _repository.SelectObject<User>(new Dictionary<string, object>()
            {
                { nameof(Models.Entity.user.user_id), userId },
                // { nameof(Models.Entity.user.password), SecurityUtil.HashPassword(oldPassword)}
            }) as User;

            
            if(user == null|| !SecurityUtil.VerifyPassword(oldPassword, user.Password))
            {
                return res.OnError(ErrorCode.Err1000, ErrorMessage.Err1000);
            };

            await _repository.Update(new
            {
                user_id = userId,
                password = SecurityUtil.HashPassword(newPassword)
            });

            return res.OnSuccess();

        }
        /// Lấy các thông tin cá nhân của người dùng
        
        
        public async Task<IServiceResult> GetUserInfo()
        {
            var res = new ServiceResult();

            var userId = this.ServiceCollection.AuthUtil.GetCurrentUserId();
            var user = await _repository.SelectObject<User>(new Dictionary<string, object>()
            {
                { nameof(Models.Entity.user.user_id), userId }
            }) as User;

            user.Password = null;

            return res.OnSuccess(user); ;
        }

        
        /// Cập nhật các thông tin cá nhân của người dùng
// public async Task<IServiceResult> UpdateUserInfo(UpdateUserInfoParam param)
//         {
//             var res = new ServiceResult();

//             // Cập nhật thông tin user
//             var userId = this.ServiceCollection.AuthUtil.GetCurrentUserId();

//             var user = await _repository.SelectObject<User>(new Dictionary<string, object>()
//             {
//                 { nameof(Models.Entity.user.user_id), userId }
//             }) as User;

//             if(user == null)
//             {
//                 return res.OnError(ErrorCode.Err9999);
//             }


//             // Upload ảnh đại diện
//             string avatarLink = null;
//             if (param.Avatar != null)
//             {
//                 if (!FunctionUtil.IsImageFile(param.Avatar))
//                 {
//                     return res.OnError(ErrorCode.Err9003, ErrorMessage.Err9003);
//                 }

//                 if (!FunctionUtil.IsValidFileSize(param.Avatar))
//                 {
//                     return res.OnError(ErrorCode.Err9002, ErrorMessage.Err9002);
//                 }

//                 if (param.Avatar.Length > 0)
//                 {
//                     using (var ms = new MemoryStream())
//                     {
//                         param.Avatar.CopyTo(ms);
//                         var fileBytes = ms.ToArray();

//                         avatarLink = await _storage.UploadAsync(StoragePath.Avatar, userId.ToString(), fileBytes);
//                     }

//                 }
//             }

//             var result = await _repository.Update(new 
//             {
//                 user_id = (Guid)userId,
//                 display_name = param.DisplayName ?? user.DisplayName,
//                 full_name = param.FullName ?? user.FullName,
//                 birthday = param.Birthday != null ? DateTime.Parse(param.Birthday) : user.Birthday,
//                 position = param.Position ?? user.Position,
//                 avatar = avatarLink ?? user.Avatar
//             });

//             if(!result)
//             {
//                 return res.OnError(ErrorCode.Err9999);
//             }

//             res.OnSuccess();
//             res.Data = new
//             {
//                 FullName = param.FullName,
//                 Position = param.Position,
//                 Birthday = param.Birthday ,
//                 DisplayName = param.DisplayName,
//             };
//             return res;
//         }
            public async Task<IServiceResult> UpdateUserInfo(UpdateUserInfoParam param)
            {
                var res = new ServiceResult();

                // Cập nhật thông tin user
                var userId = this.ServiceCollection.AuthUtil.GetCurrentUserId();

                var user = await _repository.SelectObject<User>(new Dictionary<string, object>()
                {
                    { nameof(Models.Entity.user.user_id), userId }
                }) as User;

                if (user == null)
                {
                    return res.OnError(ErrorCode.Err9999, "User not found.");
                }

                // Upload ảnh đại diện
                byte[] avatarBytes = null;
                if (param.Avatar != null)
                {
                    if (!FunctionUtil.IsImageFile(param.Avatar))
                    {
                        return res.OnError(ErrorCode.Err9003, ErrorMessage.Err9003);
                    }

                    if (!FunctionUtil.IsValidFileSize(param.Avatar))
                    {
                        return res.OnError(ErrorCode.Err9002, ErrorMessage.Err9002);
                    }

                    using (var ms = new MemoryStream())
                    {
                        param.Avatar.CopyTo(ms);
                        avatarBytes = ms.ToArray();
                    }
                }

                var updateData = new
                {
                    display_name = param.DisplayName ?? user.DisplayName,
                    full_name = param.FullName ?? user.FullName,
                    birthday = param.Birthday != null ? DateTime.Parse(param.Birthday) : user.Birthday,
                    position = param.Position ?? user.Position,
                    avatar = avatarBytes,
                };

                res.OnSuccess();
                res.Data = new
                {
                    FullName = param.DisplayName,
                    Position = param.Position,
                    Birthday = param.Birthday,
                    DisplayName = param.FullName,
                    Avatar = avatarBytes != null ? Convert.ToBase64String(avatarBytes) : null
                };

                return res;
            }


        #endregion

    }


}
