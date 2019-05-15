using System;

namespace student_game.backend.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product(string name, decimal price, string description, string userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            UserId = userId;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Product(string name, decimal price, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}