using System;
using Microsoft.EntityFrameworkCore;
using TelegramAspMvcDotnetBotDb.Models;

namespace TelegramAspMvcDotnetBotDb
{
    public class MainDbContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Flag> Flags { get; set; }
        public DbSet<Game> Games { get; set; }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>()
                .HasMany(m => m.Games)
                .WithOne(m => m.Player)
                .HasForeignKey(m => m.PlayerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Flag>()
                .HasMany(m => m.Games)
                .WithOne(m => m.Flag)
                .HasForeignKey(m => m.FlagID)
                .OnDelete(DeleteBehavior.Cascade);

            ////builder.Entity<Game>()
            ////    .HasOne(m => m.Player)
            ////    .WithMany(m => m.Game)
            ////    .HasForeignKey(m => m.PlayerID)
            ////    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Player>()
                .HasIndex(m => m.TGId);

            builder.Entity<Flag>()
                .HasIndex(m => m.Number);

            builder.Entity<Flag>()
                .HasIndex(m => m.ImageName);
        }   
    }
}
