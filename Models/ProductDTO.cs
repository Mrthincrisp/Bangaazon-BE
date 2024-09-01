﻿namespace Bangazon.Models
{
    public class ProductDTO
    {
        public int? UserId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
