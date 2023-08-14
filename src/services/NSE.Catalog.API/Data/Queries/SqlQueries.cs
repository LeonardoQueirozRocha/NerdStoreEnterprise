using System.Text;

namespace NSE.Catalog.API.Data.Queries;

public static class SqlQueries
{
    public const string SELECT = @"SELECT Id,
                                          Name,
                                          Description,
                                          Active,
                                          Value,
                                          RegistrationDate,
                                          Image,
                                          QuantityInStock
                                   FROM   Products";

    public const string SELECT_COUNT = "SELECT COUNT(Id) FROM Products";

    public static string GetPagedProductsQuery(int pageSize, int pageIndex, string query = null)
    {
        var queryFilter = "WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%')";
        var pagination = $@"ORDER BY [Name]
                            OFFSET {pageSize * (pageIndex - 1)} ROWS
                            FETCH NEXT {pageSize} ROWS ONLY";

        var sb = new StringBuilder();
        sb.Append(SELECT);
        sb.AppendLine();
        sb.AppendLine(queryFilter);
        sb.AppendLine();
        sb.AppendLine(pagination);
        sb.AppendLine();
        sb.AppendLine(SELECT_COUNT);
        sb.AppendLine();
        sb.AppendLine(queryFilter);

        return sb.ToString();
    }
}

