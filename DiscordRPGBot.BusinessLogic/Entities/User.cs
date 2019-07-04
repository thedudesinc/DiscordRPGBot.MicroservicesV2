using System;
using System.Collections.Generic;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string DiscordId { get; set; }
        public string DiscordName { get; set; }
        public ICollection<PlayerCharacter> Characters { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
