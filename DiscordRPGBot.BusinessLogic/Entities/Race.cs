using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StrongMod { get; set; }
        public int FastMod { get; set; }
        public int SmartMod { get; set; }
        public int ToughMod { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<PlayerCharacter> PlayerCharacters { get; set; }
        //public virtual ICollection<Action> Actions { get; set; }
    }
}
