using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Application.Queries;

namespace Xxx.Infrastructure.Queries
{
    public class BarService : IBarService
    {
        private readonly string _connectionString;

        public BarService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<BarDto>> GetAllBarsWithFoos(CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var barQuery = BarQueries.AllWithFoos();

                var barEntries = new Dictionary<int, BarDto>();

                var result = await connection.QueryAsync<BarDto, BazDto, FooDto, BarDto>(barQuery.Sql,
                    (bar, baz, foo) =>
                    {
                        if (!barEntries.TryGetValue(bar.Id, out BarDto barEntry))
                        {
                            barEntry = bar;
                            barEntry.Bazs = new List<BazDto>();
                            barEntries[bar.Id] = barEntry;
                        }

                        barEntry.Bazs.Add(baz);
                        barEntry.Foo = foo;

                        return barEntry;
                    });

                return result;
            }
        }
    }
}
