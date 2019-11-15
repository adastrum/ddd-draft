namespace Xxx.Infrastructure.Queries
{
    public class BarQueries
    {
        public static QueryObject AllWithFoos()
        {
            return new QueryObject(
                "select b.Id, b.Created," +
                "bb.Id, bb.Code, bb.Description, bb.Quantity," +
                "f.Id, f.Name_FirstName, f.Name_MiddleName, f.Name_SecondName" +
                "from Bars b" +
                "join Bazs bb on bb.BarId = b.Id" +
                "left join Foos f on f.Id = b.FooId", null);
        }
    }
}
