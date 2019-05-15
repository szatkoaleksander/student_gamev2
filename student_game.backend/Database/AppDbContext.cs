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

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Products)   
                .WithOne(c => c.User).HasForeignKey(x => x.UserId);  

            /* TODO 
            * Remove seeds in future
            *
            */
            var d1 = new Dungeon(1);
            var d2 = new Dungeon(2);
            var d3 = new Dungeon(3);
            var d4 = new Dungeon(4);
            var d5 = new Dungeon(5);

           // modelBuilder.Entity<Dungeon>().HasData(d1, d2, d3, d4, d5);
            modelBuilder.Entity<Dungeon>().HasData(d2);
            modelBuilder.Entity<Dungeon>().HasData(d3);
            modelBuilder.Entity<Dungeon>().HasData(d4);
            modelBuilder.Entity<Dungeon>().HasData(d5);

            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d1.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d1.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d1.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d1.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d1.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d2.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d2.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d2.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d2.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d2.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d3.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d3.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d3.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d3.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d3.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d4.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d4.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d4.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d4.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d4.Id});
            // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d5.Id});
            // // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d5.Id});
            // // modelBuilder.Entity<Enemy>().HasData(new Enemy() { DungeonId = d5.Id});

            // modelBuilder.Entity<Product>().HasData(new Product("Lawka", 100, "ALA MA KOTA"));
            // modelBuilder.Entity<Product>().HasData(new Product("Lawka1", 1200, "ALA MA KOTA"));
            // modelBuilder.Entity<Product>().HasData(new Product("Lawka1", 3100, "ALA MA KOTA"));
            // modelBuilder.Entity<Product>().HasData(new Product("Lawka1", 5100, "ALA MA KOTA"));
            // modelBuilder.Entity<Product>().HasData(new Product("Lawka1", 99100, "ALA MA KOTA"));
        
        }
    }
}