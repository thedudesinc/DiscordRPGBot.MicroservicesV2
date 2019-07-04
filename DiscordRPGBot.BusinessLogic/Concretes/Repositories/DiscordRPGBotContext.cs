using DiscordRPGBot.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<SpecialAbility> SpecialAbilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DiscordId).IsRequired();
                entity.Property(e => e.DiscordName).IsRequired();
            });

            modelBuilder.Entity<PlayerCharacter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne<Race>();
                entity.HasOne<Class>();
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne<SpecialAbility>();
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Rarity).IsRequired();
                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemId).IsRequired();
                entity.Property(e => e.PlayerCharacterId).IsRequired();
            });

            modelBuilder.Entity<SpecialAbility>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.IsRPAbility).IsRequired();
                entity.Property(e => e.IsCombatAbility).IsRequired();
            });
        }
    }
}
