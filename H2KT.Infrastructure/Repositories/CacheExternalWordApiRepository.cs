using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.Entity;
using H2KT.Core.Utils;

namespace H2KT.Infrastructure.Repositories
{
    public class CacheExternalWordApiRepository : BaseRepository<cache_external_word_api>, ICacheExternalWordApiRepository
    {
        #region Constructors
        public CacheExternalWordApiRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods
        #endregion

    }
}
