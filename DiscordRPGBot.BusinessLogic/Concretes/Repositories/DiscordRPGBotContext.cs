using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Enums;
using Microsoft.EntityFrameworkCore;
using DiscordRPGBot.BusinessLogic.SeedDataClasses;

namespace DiscordRPGBot.BusinessLogic.Repositories
{
    public class DiscordRPGBotContext : DbContext
    {
        public DiscordRPGBotContext(DbContextOptions<DiscordRPGBotContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<LocationAction> LocationActions { get; set; }
        public DbSet<ItemAction> ItemActions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattleLog> BattlesLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var seedData = new SeedData();

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DiscordId).IsRequired();
                entity.Property(e => e.IsPremiumMember).HasConversion<int>();
                entity.HasMany(u => u.Characters).WithOne(pc => pc.User).HasForeignKey(u => u.UserId);
                entity.Property(e => e.ActiveCharacter).IsRequired(false);
            });
               
            modelBuilder.Entity<PlayerCharacter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(pc => pc.Class).WithMany(c => c.PlayerCharacters).HasForeignKey(pc => pc.ClassId);
                entity.HasOne(pc => pc.Race).WithMany(c => c.PlayerCharacters).HasForeignKey(pc => pc.RaceId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasMany(a => a.Actions);
                entity.Property(a => a.IsHostile).HasConversion<int>();
                entity.HasData(seedData.locations);
            });

            modelBuilder.Entity<LocationAction>(entity =>
            {
                entity.HasOne(pc => pc.Location).WithMany(c => c.Actions).HasForeignKey(pc => pc.LocationId);
                entity.HasData(seedData.locationActions);
            });

            modelBuilder.Entity<ItemAction>(entity =>
            {
                entity.HasOne(pc => pc.Item).WithMany(c => c.Actions).HasForeignKey(pc => pc.ItemId);
                entity.HasData(seedData.itemActions);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasData(seedData.classes);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasData(seedData.races);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Rarity).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.HasData(seedData.items);
            });

            modelBuilder.Entity<Inventory>()
                .HasKey(bc => new { bc.PlayerCharacterId, bc.ItemId });
            modelBuilder.Entity<Inventory>()
                .HasOne(bc => bc.PlayerCharacter)
                .WithMany(b => b.Items)
                .HasForeignKey(bc => bc.PlayerCharacterId);
            modelBuilder.Entity<Inventory>()
                .HasOne(bc => bc.Item)
                .WithMany(c => c.PlayerCharacters)
                .HasForeignKey(bc => bc.ItemId);
        }
    }
}
