namespace Bangazon.API
{
    public class CategoryAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/category", (BangazonDbContext db) =>
            {
                var categories = db.Categories.ToList();
                if (categories == null)
                {
                    return Results.NotFound("Categories not found");
                }
                return Results.Ok(categories);
            });
        }
    }
}
