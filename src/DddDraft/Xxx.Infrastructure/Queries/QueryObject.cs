namespace Xxx.Infrastructure.Queries
{
    public class QueryObject
    {
        public QueryObject(string sql, object queryParameters)
        {
            Sql = sql;
            Param = queryParameters;
        }

        public string Sql { get; private set; }

        public object Param { get; private set; }
    }
}
