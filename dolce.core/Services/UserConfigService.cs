using H2KT.Core.Constants;
using H2KT.Core.Enums;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Services
{
    
    /// Serivce xử lý account
    
    public class UserConfigService : BaseService, IUserConfigService
    {
        #region Field

        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructor

        public UserConfigService(IUserRepository userRepository,
            INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {
            _userRepository = userRepository;
        }



        #endregion

        #region Method

        
        /// Lấy danh sách tất cả config: 
        
        /// <param name="userId"></param>
        
        public async Task<UserConfigData> GetAllConfigData(string userId = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = this.ServiceCollection.AuthUtil.GetCurrentUserId()?.ToString();
            }

            var tables = new string[]
            {
                nameof(concept_link),
                nameof(example_link),
                nameof(tone),
                nameof(mode),
                nameof(register),
                nameof(nuance),
                nameof(dialect)
            };

            // Không dùng từ "params"
            var param = new Dictionary<string, Dictionary<string, object>>()
            {
                {
                    nameof(concept_link),
                    new Dictionary<string, object> { { nameof(concept_link.user_id), userId } }
                },
                {
                    nameof(example_link),
                    new Dictionary<string, object> { { nameof(example_link.user_id), userId } }
                },
                {
                    nameof(tone),
                    new Dictionary<string, object> { { nameof(tone.user_id), userId } }
                },
                {
                    nameof(mode),
                    new Dictionary<string, object> { { nameof(mode.user_id), userId } }
                },
                {
                    nameof(register),
                    new Dictionary<string, object> { { nameof(register.user_id), userId } }
                },
                {
                    nameof(nuance),
                    new Dictionary<string, object> { { nameof(nuance.user_id), userId } }
                },
                {
                    nameof(dialect),
                    new Dictionary<string, object> { { nameof(dialect.user_id), userId } }
                }
            };

            var queryRes = await _userRepository.SelectManyObjects(tables, param) as Dictionary<string, object>;

            if (queryRes == null)
            {
                return null;
            }

            var res = new UserConfigData
            {
                ListConceptLink = queryRes[nameof(concept_link)] as List<concept_link>,
                ListExampleLink = queryRes[nameof(example_link)] as List<example_link>,
                ListTone = queryRes[nameof(tone)] as List<tone>,
                ListMode = queryRes[nameof(mode)] as List<mode>,
                ListRegister = queryRes[nameof(register)] as List<register>,
                ListNuance = queryRes[nameof(nuance)] as List<nuance>,
                ListDialect = queryRes[nameof(dialect)] as List<dialect>
            };
            //var lstExampleLink = (queryRes[nameof(example_link)] as List<object>).Cast<example_link>().ToList()

            return res;
        }

        
        /// Lấy danh sách concept link
        
        
        public async Task<IServiceResult> GetListConceptLink()
        {
            var res = new ServiceResult();

            var userId = this.ServiceCollection.AuthUtil.GetCurrentUserId();
            var data = await _userRepository.SelectObjects<ConceptLink>(new Dictionary<string, object>
            {
                { nameof(concept_link.user_id), userId }
            }) as List<ConceptLink>;

            data?.Add(new ConceptLink
            {
                ConceptLinkId = Guid.Empty,
                SysConceptLinkId = Guid.Empty,
                UserId = userId,
                ConceptLinkName = "No link",
                ConceptLinkType = (int)ConceptLinkType.NoLink,
                SortOrder = 0
            });

            res.Data = data?.OrderBy(x => x.SortOrder);

            return res;
        }

        
        /// Lấy danh sách example link
        
        
        public async Task<IServiceResult> GetListExampleLink()
        {
            var res = new ServiceResult();

            var userId = this.ServiceCollection.AuthUtil.GetCurrentUserId();
            var data = await _userRepository.SelectObjects<ExampleLink>(new Dictionary<string, object>
            {
                { nameof(example_link.user_id), userId }
            }) as List<ExampleLink>;

            data?.Add(new ExampleLink
            {
                ExampleLinkId = Guid.Empty,
                SysExampleLinkId = Guid.Empty,
                UserId = userId,
                ExampleLinkName = "No link",
                ExampleLinkType = (int)ExampleLinkType.NoLink,
                SortOrder = 0
            });

            res.Data = data?.OrderBy(x => x.SortOrder);

            return res;
        }

        
        /// Lấy danh sách example attribute
        
        
        public async Task<IServiceResult> GetListExampleAttribute()
        {
            var res = new ServiceResult();

            var configData = await this.GetAllConfigData();
            var lstExampleLink = (await this.GetListExampleLink()).Data;
            res.Data = new
            {
                ListExampleLink = lstExampleLink,
                ListTone = this.ServiceCollection.Mapper.Map<List<Tone>>(configData.ListTone).OrderBy(x => x.SortOrder),
                ListMode = this.ServiceCollection.Mapper.Map<List<Mode>>(configData.ListMode).OrderBy(x => x.SortOrder),
                ListRegister = this.ServiceCollection.Mapper.Map<List<Register>>(configData.ListRegister).OrderBy(x => x.SortOrder),
                ListNuance = this.ServiceCollection.Mapper.Map<List<Nuance>>(configData.ListNuance).OrderBy(x => x.SortOrder),
                ListDialect = this.ServiceCollection.Mapper.Map<List<Dialect>>(configData.ListDialect).OrderBy(x => x.SortOrder),
            };

            return res;
        }
        #endregion

    }
}
