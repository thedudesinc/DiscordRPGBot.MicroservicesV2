using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string DiscordId { get; set; }
        public long? ActiveCharacter { get; set; }
        public bool IsPremiumMember { get; set; } = false;
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public virtual ICollection<PlayerCharacter> Characters { get; set; }
    }
}
