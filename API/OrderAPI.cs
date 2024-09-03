using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.Extensions.Options;
namespace Bangazon.API
{
    public class OrderAPI
    {
        public static void map(WebApplication app)
        {
            //Add a new order
            app.MapPost("/order/{id}", async (BangazonDbContext db, int id) =>
            {
                // Retrieve OrderItems based on id
                var orderItems = await db.OrderItems
                    .Include(oi => oi.Product)
                    .Include(oi => oi.User)
                    .Where(oi => oi.UserId == id)
                    .ToListAsync();

                if (orderItems == null)
                {
                    return Results.NotFound(new { Message = "Products not found" });
                }

                var products = new List<OrderProducts>();
                foreach (var item in orderItems)
                {
                    var sellerName = await db.Users
                        .Where(u => u.Id == item.Product.UserId)
                        .Select(u => u.UserName)
                        .FirstOrDefaultAsync();

                    products.Add(new OrderProducts
                    {
                        Name = item.Product.Name,
                        Price = item.Product.Price,
                        ProductNumber = item.Product.ProductId,
                        SellerId = item.Product.UserId,
                        SellerName = sellerName
                    });
                }

                var newOrder = new Order
                {
                    BuyerId = id,
                    Products = products
                };

                db.Orders.Add(newOrder);
                await db.SaveChangesAsync();

                return Results.Created($"/order/{newOrder.Id}", newOrder);
            });

            //GET a user's orders
            app.MapGet("/order/{userId}", async (BangazonDbContext db, int userId) =>
            {
                // Retrieve Orders for the specified user
                var orders = await db.Orders
                    .Where(o => o.BuyerId == userId)
                    .Include(o => o.Products)
                    .ToListAsync();

                if (orders == null)
                {
                    return Results.NotFound("Order is null");
                }

                return Results.Ok(orders);

            });
        }
    }
}
