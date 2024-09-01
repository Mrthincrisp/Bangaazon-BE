using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;


namespace Bangazon.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime TimeMade { get; set; }
        public User? User { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public Category? Category { get; set; }

    }
}
