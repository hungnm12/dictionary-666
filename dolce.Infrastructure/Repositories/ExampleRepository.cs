using Dapper;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.Param;
using H2KT.Core.Utils;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace H2KT.Infrastructure.Repositories
{
    public class ExampleRepository : BaseRepository<example>, IExampleRepository
    {
        #region Constructors
        public ExampleRepository(INhom2ServiceCollection serviceCollection) : base(serviceCollection)
        {

        }

        #endregion

        #region Methods
        
        /// Tìm kiếm example
public async Task<List<Example>> SearchExample(SearchExampleParam param)
        {
            using (var connection = await this.CreateConnectionAsync())
            {
                var parameters = new DynamicParameters();
                parameters.Add("$DictionaryId", param.DictionaryId);
                var keyWord = '%' + param.Keyword + '%';
                parameters.Add("@Keyword", keyWord);
                parameters.Add("$ToneId", param.ToneId);
                parameters.Add("$ModeId", param.ModeId);
                parameters.Add("$RegisterId", param.RegisterId);
                parameters.Add("$NuanceId", param.NuanceId);
                parameters.Add("$DialectId", param.DialectId);

                string strListLinkedConceptId = null;
                if(param.ListLinkedConceptId != null && param.ListLinkedConceptId.Count >= 0)
                {
                    strListLinkedConceptId = SerializeUtil.SerializeObject(param.ListLinkedConceptId);
                }
                parameters.Add("$ListLinkedConceptId", strListLinkedConceptId);
                parameters.Add("$IsSearchUndecided", param.IsSearchUndecided);
                parameters.Add("$IsFulltextSearch", param.IsFulltextSearch);

                var res = await connection.QueryAsync<example>(
                    sql: @"Select * from example where detail Like @Keyword",
                    param: parameters,
                    commandTimeout: ConnectionTimeout);

                if (res != null)
                {
                    return this.ServiceCollection.Mapper.Map<List<Example>>(res);
                }

                return new List<Example>();
            }
        }
        #endregion

    }
}
