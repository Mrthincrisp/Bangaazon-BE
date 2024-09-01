﻿using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
