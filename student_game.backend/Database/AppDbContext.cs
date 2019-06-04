using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using student_game.backend.Models;

namespace student_game.backend.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dungeon>()
                .HasMany(e => e.Enemy)   
                .WithOne(c => c.Dungeon).HasForeignKey(x => x.DungeonId);  

            modelBuilder.Entity<AppUserProduct>()
                .HasKey(x => new { x.AppUserId, x.ProductId });  
            modelBuilder.Entity<AppUserProduct>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.AppUserProduct)
                .HasForeignKey(x => x.AppUserId);  
            modelBuilder.Entity<AppUserProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.AppUserProduct)
                .HasForeignKey(x => x.ProductId);

            var d1 = new Dungeon(1);
            var d2 = new Dungeon(2);
            var d3 = new Dungeon(3);
            var d4 = new Dungeon(4);
            var d5 = new Dungeon(5);

            modelBuilder.Entity<Dungeon>().HasData(d1, d2, d3, d4, d5);
            modelBuilder.Entity<Enemy>().HasData(
                new Enemy() { DungeonId = d1.Id },
                new Enemy() { DungeonId = d1.Id },
                new Enemy() { DungeonId = d1.Id },
                new Enemy() { DungeonId = d1.Id },
                new Enemy() { DungeonId = d1.Id },
                new Enemy() { DungeonId = d2.Id },
                new Enemy() { DungeonId = d2.Id },
                new Enemy() { DungeonId = d2.Id },
                new Enemy() { DungeonId = d2.Id },
                new Enemy() { DungeonId = d2.Id },
                new Enemy() { DungeonId = d3.Id },
                new Enemy() { DungeonId = d3.Id },
                new Enemy() { DungeonId = d3.Id },
                new Enemy() { DungeonId = d3.Id },
                new Enemy() { DungeonId = d3.Id },
                new Enemy() { DungeonId = d4.Id },
                new Enemy() { DungeonId = d4.Id },
                new Enemy() { DungeonId = d4.Id },
                new Enemy() { DungeonId = d4.Id },
                new Enemy() { DungeonId = d4.Id },
                new Enemy() { DungeonId = d5.Id },
                new Enemy() { DungeonId = d5.Id },
                new Enemy() { DungeonId = d5.Id },
                new Enemy() { DungeonId = d5.Id },
                new Enemy() { DungeonId = d5.Id }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product("Piwo", 100, "Piweczko jest jak rosol", 1),
                new Product("Kilo kurczaka", 500, "Bialeczko", 2),
                new Product("Ubrania", 1500, "Bo student ubrany byc musi", 3),
                new Product("Mydelko Fa", 5000, "Ty i ja, ty i ja", 4),
                new Product("Drukarka", 10000, "Bo edukacja jest darmowa", 5),
                new Product("Dziewczyna", 20000, "...", 6),
                new Product("Kawalerka", 30000, "Oaza spokoju", 7)
            );
        }
    }
}