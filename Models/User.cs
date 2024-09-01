using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool Seller { get; set; }
        public string? StoreName { get; set; }
        public string? StoreDescription { get; set; }
        public List<Product>? Products { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
