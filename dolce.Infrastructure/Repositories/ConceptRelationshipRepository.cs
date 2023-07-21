using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Utils;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class ConceptRelationshipRepository : BaseRepository<concept_relationship>, IConceptRelationshipRepository
    {
        #region Constructors
        public ConceptRelationshipRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods
        #endregion

    }
}
