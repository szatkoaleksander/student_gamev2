using System;
using System.Collections.Generic;

namespace student_game.backend.Models
{
    public class Enemy
    {
        public Guid Id { get; set; }
        public int Hp { get; set; } = 100;
        public double Attack { get; set; } = 2;
        public double Defense { get; set; } = 2;
        public Guid DungeonId { get; set; }
        public virtual Dungeon Dungeon { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Enemy() 
        {
            Id = Guid.NewGuid();

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Enemy(Guid dungeon) 
        {
            Id = Guid.NewGuid();
            DungeonId = dungeon;
            
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}