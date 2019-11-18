namespace Xxx.Infrastructure.Queries
{
    public class QueryObject
    {
        public QueryObject(string sql, object param)
        {
            Sql = sql;
            Param = param;
        }

        public string Sql { get; private set; }

        public object Param { get; private set; }
    }
}
