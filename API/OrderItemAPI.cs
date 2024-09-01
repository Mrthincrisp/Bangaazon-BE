using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.Extensions.Options;
namespace Bangazon.API
{
    public class OrderItemAPI
    {
        public static void Map(WebApplication app)
        {

            //Get a User's order Items
            app.MapGet("/user/{uid}/orderitem", async (BangazonDbContext db, int uid) =>
            {
                var userOrders = await db.OrderItems?
                    .Where(u => u.UserId == uid)
                    .Include(oi => oi.Product)
                    .ToListAsync();

              

                return Results.Ok(userOrders);
            });

            //Post An Order Item
            app.MapPost("/user/orderitem", (BangazonDbContext db, OrderItemDTO newOrder) =>
            {
                User? newOrderUser = db.Users.Include(u => u.OrderItems).SingleOrDefault(u => u.Id == newOrder.UserId);

                if (newOrderUser == null)
                {
                    return Results.NotFound(new { Message = "User not found." });
                }

                OrderItem? newOrderItem = new OrderItem
                {
                    UserId = newOrder.UserId,
                    ProductId = newOrder.ProductId,
                };

                newOrderUser.OrderItems.Add(newOrderItem);

                db.SaveChanges();
                return Results.Created("/user/orderItem", newOrder);
            });

            //delete an orderItem
            app.MapDelete("orderitem/{orderId}", (BangazonDbContext db, int orderId) =>
            {

                var orderItemToDelete = db.OrderItems.FirstOrDefault(o => o.OrderItemId == orderId);
                if (orderItemToDelete == null) 
                {
                    return Results.NotFound("OrderItem not found");
                }

                db.OrderItems.Remove(orderItemToDelete);
                db.SaveChanges();
                return Results.Ok("Order Item Deleted");

            });

        }
    }
}