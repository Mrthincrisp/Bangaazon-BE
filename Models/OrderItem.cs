using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int UserId {  get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
    }
}
