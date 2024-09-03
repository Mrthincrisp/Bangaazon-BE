namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public List<OrderProducts>? Products { get; set; }
    }

    public class OrderProducts
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int ProductNumber { get; set; }
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
    }

}
