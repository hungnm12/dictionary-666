using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.Entity;
using H2KT.Core.Utils;

namespace H2KT.Infrastructure.Repositories
{
    public class CacheSqlRepository : BaseRepository<cache_sql>, ICacheSqlRepository
    {
        #region Constructors
        public CacheSqlRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods
        #endregion

    }
}
