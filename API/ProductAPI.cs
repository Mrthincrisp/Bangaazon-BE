using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using AutoMapper;
using System.Runtime.InteropServices;
namespace Bangazon.API

{
    public class ProductAPI
    {

        public static void Map(WebApplication app)
        {
            //Get all Products
            app.MapGet("/product/", (BangazonDbContext db) =>
            {
                var products = db.Products;

                return Results.Ok(products);
            });

            //Get products by id
            app.MapGet("/product/{id}", (BangazonDbContext db, int id) =>
            {
                var product = db.Products.Include(p => p.Category)
                .SingleOrDefault(p => p.ProductId == id);

                if (product == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(product);
            });

            //Get products by user
            app.MapGet("/product/user/{id}", (BangazonDbContext db, int id) =>
            {

                return db.Products.Where(p => p.UserId == id);
            });

            //Delete a product
            app.MapDelete("/product/{id}", (BangazonDbContext db, int id) =>
            {
                if (db.Products == null)
                {
                    return Results.Problem("Product is null", statusCode: 500);
                }

                var ProductToDelete = db.Products.FirstOrDefault(p => p.ProductId == id);

                if(ProductToDelete == null)
                {
                    return Results.NotFound("No Product id found");
                }

                db.Products.Remove(ProductToDelete);
                db.SaveChanges();
                return Results.Ok("Product deleted");
            });

            //Post a Product
            app.MapPost("/products/", (BangazonDbContext db, IMapper mapper, ProductDTO newProductDto) =>
            {
                var newProduct = mapper.Map<Product>(newProductDto);
                newProduct.TimeMade = DateTime.UtcNow;

                try
                {
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    return Results.Created($"/products/{newProduct.ProductId}", newProduct);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to add Product");
                }
            });

            //Patch a Product
            app.MapPatch("/products/{id}", (BangazonDbContext db, IMapper mapper, int id, ProductDTO updatedProductDto) =>
            {
                var product = db.Products.FirstOrDefault(p => p.ProductId == id);

                if (product == null)
                {
                    return Results.NotFound("No Product found");
                }

                mapper.Map(updatedProductDto, product);

                try
                {
                    db.SaveChanges();
                    return Results.Ok(product);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to update Product");
                }
            });

        }
    }
}
