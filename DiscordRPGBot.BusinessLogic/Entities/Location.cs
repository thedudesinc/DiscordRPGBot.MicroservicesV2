using System.Collections.Generic;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsHostile { get; set; }
        public virtual ICollection<LocationAction> Actions { get; set; }
    }
}
