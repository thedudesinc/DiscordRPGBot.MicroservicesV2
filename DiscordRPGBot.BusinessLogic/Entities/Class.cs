using System;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Class
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StrongMod { get; set; }
        public int FastMod { get; set; }
        public int SmartMod { get; set; }
        public int ToughMod { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }

        public virtual SpecialAbility SpecialAbility { get; set; }
    }
}
