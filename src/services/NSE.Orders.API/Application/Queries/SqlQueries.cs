namespace NSE.Orders.API.Application.Queries;

public static class SqlQueries
{
    public const string SELECT_LAST_ORDER = @"SELECT O.Id  AS 'ProductId',
                                                          O.Code,
                                                          O.UsedVoucher,
                                                          O.Discount,
                                                          O.TotalValue,
                                                          O.OrderStatus,
                                                          O.PublicPlace,
                                                          O.Number,
                                                          O.Neighborhood,
                                                          O.ZipCode,
                                                          O.Complement,
                                                          O.City,
                                                          O.[State],
                                                          OI.Id,
                                                          OI.Id AS 'ProductItemId',
                                                          OI.ProductName,
                                                          OI.Quantity,
                                                          OI.ProductImage,
                                                          OI.UnitValue
                                                   FROM   Orders O
                                                          INNER JOIN OrderItems OI
                                                                  ON O.Id = OI.OrderId
                                                   WHERE  1 = 1
                                                          AND O.CustomerId = @customerId
                                                          AND O.CreationDate BETWEEN Dateadd(minute, -3, Getdate()) AND
                                                                                     Dateadd(minute, 0, Getdate())
                                                          AND O.OrderStatus = 1
                                                   ORDER  BY O.CreationDate DESC";

    public const string SELECT_AUTHORIZED_ORDER = @"SELECT TOP 1 Orders.Id     AS 'OrderId',
                                                                 Orders.Id,
                                                                 Orders.CustomerId,
                                                                 OrderItems.Id AS 'OrderItemId',
                                                                 OrderItems.Id,
                                                                 OrderItems.ProductId,
                                                                 OrderItems.Quantity
                                                    FROM   Orders
                                                           INNER JOIN OrderItems
                                                                   ON OrderItems.OrderId = Orders.Id
                                                    WHERE  1 = 1
                                                           AND Orders.OrderStatus = 1
                                                    ORDER  BY Orders.CreationDate";
}

