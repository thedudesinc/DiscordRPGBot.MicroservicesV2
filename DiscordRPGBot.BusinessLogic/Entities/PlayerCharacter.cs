using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class PlayerCharacter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Backstory { get; set; }
        public int Age { get; set; }
        public long CurrentXP { get; set; }
        public int CurrentLevel { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public long Gold { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public long ClassId { get; set; }
        public long RaceId { get; set; }
        public long UserId { get; set; }
        public long LocationId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Race Race { get; set; }
        public virtual User User { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Inventory> Items { get; set; }
    }
}
