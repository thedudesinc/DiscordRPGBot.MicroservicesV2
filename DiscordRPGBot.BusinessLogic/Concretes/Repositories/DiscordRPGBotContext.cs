using DiscordRPGBot.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
                entity.Property(e => e.IsPremiumMember).HasConversion<int>();
                entity.HasMany(u => u.Characters).WithOne(pc => pc.User).HasForeignKey(u => u.UserId);
                entity.Property(e => e.ActiveCharacter).IsRequired(false);
            });
               
            modelBuilder.Entity<PlayerCharacter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.SpecialAbilityLastUsed).IsRequired(false);
                entity.HasOne(pc => pc.Class).WithMany(c => c.PlayerCharacters).HasForeignKey(pc => pc.ClassId);
                entity.HasOne(pc => pc.Race).WithMany(c => c.PlayerCharacters).HasForeignKey(pc => pc.RaceId);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasData(new[] {
                    new Class {
                        Id = 1,
                        Name = "Fighter",
                        Description = "Melee build. Can only use STR weapons.",
                        ImageUrl = "https://i.imgur.com/Bcv0Y2s.png",
                        StrongMod = 4,
                        FastMod = 1,
                        SmartMod = 1,
                        ToughMod = 4,
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Class
                    {
                        Id = 2,
                        Name = "Rogue",
                        Description = "Melee or Ranged build. Can only use DEX weapons.",
                        ImageUrl = "https://i.imgur.com/VCfFj8K.png",
                        StrongMod = 1,
                        FastMod = 4,
                        SmartMod = 4,
                        ToughMod = 1,
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Class
                    {
                        Id = 3,
                        Name = "Ranger",
                        Description = "Melee or Ranged build. Can use DEX or STR weapons.",
                        ImageUrl = "https://i.imgur.com/dxUnMPG.png",
                        StrongMod = 3,
                        FastMod = 3,
                        SmartMod = 2,
                        ToughMod = 2,
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Class
                    {
                        Id = 4,
                        Name = "Wizard",
                        Description = "Magic build. Can only use spells.",
                        ImageUrl = "https://i.imgur.com/8U6oW2H.png",
                        StrongMod = 1,
                        FastMod = 2,
                        SmartMod = 6,
                        ToughMod = 1,
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                });
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasData(new[] {
                    new Race
                    {
                        Id = 1,
                        Name = "Human",
                        Description = "It's a human. Duh.",
                        StrongMod = 2,
                        FastMod = 0,
                        SmartMod = 1,
                        ToughMod = 1,
                        ImageUrl = "http://www.quickmeme.com/img/a8/a8022006b463b5ed9be5a62f1bdbac43b4f3dbd5c6b3bb44707fe5f5e26635b0.jpg",
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Race
                    {
                        Id = 2,
                        Name = "Elf",
                        Description = "Graceful and intelligent. They make great wizards or rogues.",
                        StrongMod = 0,
                        FastMod = 2,
                        SmartMod = 2,
                        ToughMod = 0,
                        ImageUrl = "http://www.quickmeme.com/img/a8/a8022006b463b5ed9be5a62f1bdbac43b4f3dbd5c6b3bb44707fe5f5e26635b0.jpg",
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Race
                    {
                        Id = 3,
                        Name = "Dwarf",
                        Description = "Tough bastards they are. They make excellent fighters or rangers.",
                        StrongMod = 0,
                        FastMod = 0,
                        SmartMod = 0,
                        ToughMod = 4,
                        ImageUrl = "http://www.quickmeme.com/img/a8/a8022006b463b5ed9be5a62f1bdbac43b4f3dbd5c6b3bb44707fe5f5e26635b0.jpg",
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Race
                    {
                        Id = 4,
                        Name = "Halfling",
                        Description = "Nimble as hell. They make excellent rogues.",
                        StrongMod = 0,
                        FastMod = 4,
                        SmartMod = 0,
                        ToughMod = 0,
                        ImageUrl = "http://www.quickmeme.com/img/a8/a8022006b463b5ed9be5a62f1bdbac43b4f3dbd5c6b3bb44707fe5f5e26635b0.jpg",
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    },
                    new Race
                    {
                        Id = 5,
                        Name = "Orc",
                        Description = "Brutes through and through. They make fantastic fighters or rangers.",
                        StrongMod = 0,
                        FastMod = 4,
                        SmartMod = 0,
                        ToughMod = 0,
                        ImageUrl = "http://www.quickmeme.com/img/a8/a8022006b463b5ed9be5a62f1bdbac43b4f3dbd5c6b3bb44707fe5f5e26635b0.jpg",
                        CreatedOn = DateTimeOffset.Now,
                        UpdatedOn = DateTimeOffset.Now
                    }
                });
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
                entity.HasOne(i => i.PlayerCharacter).WithMany(p => p.Items).HasForeignKey(i => i.PlayerCharacterId);
                entity.HasOne(i => i.Item).WithMany(it => it.PlayerCharacters).HasForeignKey(i => i.ItemId);
            });

            modelBuilder.Entity<SpecialAbility>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.IsRPAbility).IsRequired().HasConversion<int>();
                entity.Property(e => e.IsCombatAbility).IsRequired().HasConversion<int>();
            });
        }
    }
}
