using System;
using RegisterLogin.Models;
using IGDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegisterLogin.Models
{
    public class Micro_API_DBContext : DbContext
    {
        public Micro_API_DBContext(DbContextOptions<Micro_API_DBContext> options)
            : base(options)
        {
        }

        protected Micro_API_DBContext()
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCollection>()
                .HasKey(gc => new { gc.GameId, gc.CollectionId });  
            modelBuilder.Entity<GameCollection>()
                .HasOne(gc => gc.Game)
                .WithMany(g => g.GameCollection)
                .HasForeignKey(gc => gc.GameId);  
            modelBuilder.Entity<GameCollection>()
                .HasOne(gc => gc.Collection)
                .WithMany(c => c.GameCollection)
                .HasForeignKey(gc => gc.CollectionId);
        }
        
        public DbSet<Game> Games { get; set; }
        
        public DbSet<Collection> Collections { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<GameCollection> GameCollections { get; set; }
    }
}