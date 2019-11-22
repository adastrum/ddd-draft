using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Xxx.Application.Queries;

namespace Xxx.Infrastructure.Queries
{
    public class BarService : IBarService
    {
        private readonly IDbConnection _dbConnection;

        public BarService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<BarDto>> GetAllBarsWithFoos(CancellationToken cancellationToken = default)
        {
            var barQuery = BarQueries.AllWithFoos();

            var barEntries = new Dictionary<int, BarDto>();

            var result = await _dbConnection.QueryAsync<BarDto, BazDto, FooDto, BarDto>(barQuery.Sql,
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
