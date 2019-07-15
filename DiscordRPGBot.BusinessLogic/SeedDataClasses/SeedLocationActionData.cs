using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Enums;

namespace DiscordRPGBot.BusinessLogic.SeedDataClasses
{
    public partial class SeedData
    {
        public readonly LocationAction[] locationActions = new[] 
        {
            new LocationAction
            {
                Id = 1,
                Description = "Go to the local tavern",
                SuccessMessageTemplate = "You enter the tavern cautiously",
                RelocateToId = 2,
                LocationId = 1
            },
            new LocationAction
            {
                Id = 2,
                Description = "Buy a beer",
                TransactionType = TransactionType.Expense,
                SuccessMessageTemplate = "You buy a beer and down it in one gulp. Your health increases by 2!",
                Amount = 1,
                LocationId = 2
            },
            new LocationAction
            {
                Id = 3,
                Description = "Gather information from the townfolk",
                SuccessMessageTemplate = "Some of the Dwarfs at the bar tell you that if you are looking for some work, talk to Roger Cline over at the sawmill.",
                FailureMessageTemplate = "You accidentally spill some of your beer on one of the bar maids. No one talks to you for very long after that.",
                LocationId = 2
            },
            new LocationAction
            {
                Id = 4,
                Description = "Start a bar fight",
                SuccessMessageTemplate = "You couldn't stand the way the townsfolk looked at you. You punch the nearest one in the face. A fight ensues.",
                LocationId = 2
            },
            new LocationAction
            {
                Id = 5,
                Description = "Go to the sawmill",
                SuccessMessageTemplate = "You enter the sawmill and are greeted by one of the workers.",
                RelocateToId = 3,
                LocationId = 1
            },
            new LocationAction
            {
                Id = 6,
                Description = "Leave the tavern",
                SuccessMessageTemplate = "You leave the tavern, ready to take on anything.",
                RelocateToId = 1,
                LocationId = 2
            },
        };
    }
}
