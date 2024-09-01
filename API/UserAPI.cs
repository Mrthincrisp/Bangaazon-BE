using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
namespace Bangazon.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //Check for a User
            app.MapGet("/checkUser/{uid}", (BangazonDbContext db, string uid) =>
            {
                var user = db.Users?.FirstOrDefault(u => u.Uid == uid);
                if (user == null)
                {
                    return Results.NotFound("User not registered");
                }

                return Results.Ok(user);
            });

            //Post a User
            app.MapPost("/register", (BangazonDbContext db, User newUser) =>
            {
                try
                {
                    db.Users?.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to register user");
                }
            });

            //Edit a User
            app.MapPatch("/user/store/{id}", (BangazonDbContext db, int id, User updateUser) =>
            {
                var userData = db.Users.FirstOrDefault(b => b.Id == id);

                if (userData == null)
                {
                    return Results.NotFound("User not found");
                }

                userData.UserName = updateUser.UserName;
                userData.Email = updateUser.Email;
                userData.Seller = updateUser.Seller;
                userData.StoreName = updateUser.StoreName;
                userData.StoreDescription = updateUser.StoreDescription;
                db.SaveChanges();
                return Results.Ok("User store updated");
            });
        }
    }
}