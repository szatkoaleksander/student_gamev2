using System;

namespace student_game.backend.Models
{
    public class AppUserProduct
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}