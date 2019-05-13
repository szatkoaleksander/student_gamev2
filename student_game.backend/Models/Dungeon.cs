using System;
using System.Collections.Generic;

namespace student_game.backend.Models
{
    public class Dungeon
    {
        public Guid Id { get; set; }
        public int Level { get; set; }
        public virtual ICollection<Enemy> Enemy { get; set; }

        public Dungeon(int level)
        {
            Id = Guid.NewGuid();
            Level = level;
            Enemy = new List<Enemy>();
        }

        public Dungeon()
        {
            //Id = Guid.NewGuid();
        }
    }
}