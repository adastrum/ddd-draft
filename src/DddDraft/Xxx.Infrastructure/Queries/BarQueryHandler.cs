using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Xxx.Infrastructure.Queries
{
    public class BarQueryHandler
    {
        private readonly string _connectionString;

        public BarQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<BarDto>> GetAllBarsWithFoos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.Query<BarDto>(BarQueries.AllWithFoos());

                return result;
            }
        }
    }
}
