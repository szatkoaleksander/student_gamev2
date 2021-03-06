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

            /* TODO 
            * Remove seeds in future
            *
            */
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
                new Product("test", 100, "tes_testsetset"),
                new Product("test1", 100, "tes_testsetset1"),
                new Product("test2", 100, "tes_testsetset2"),
                new Product("test3", 100, "tes_testsetset3"),
                new Product("test4", 100, "tes_testsetset4"),
                new Product("test5", 100, "tes_testsetset5"),
                new Product("test6", 100, "tes_testsetset6")
            );
        }
    }
}