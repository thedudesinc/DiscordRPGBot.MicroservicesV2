using DiscordRPGBot.BusinessLogic.Entities;

namespace DiscordRPGBot.BusinessLogic.SeedDataClasses
{
    public partial class SeedData
    {
        public readonly Race[] races = new[] 
        {
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
            }
        };
    }
}
