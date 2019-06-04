using System;
using System.Collections.Generic;

namespace student_game.backend.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<AppUserProduct> AppUserProduct { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product(string name, decimal price, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;

            AppUserProduct = new List<AppUserProduct>();

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}