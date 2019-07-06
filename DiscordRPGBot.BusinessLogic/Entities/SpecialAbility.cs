using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class SpecialAbility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRPAbility { get; set; }
        public bool IsCombatAbility { get; set; }
        public virtual Class Class { get; set; }
    }
}
