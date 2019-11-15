using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Xxx.Infrastructure.Queries
{
    public static class QueryObjectExtensions
    {
        public static async Task<IEnumerable<T>> Query<T>(this IDbConnection connection, QueryObject queryObject)
        {
            var result = await connection.QueryAsync<T>(queryObject.Sql, queryObject.Param);

            return result;
        }
    }
}
