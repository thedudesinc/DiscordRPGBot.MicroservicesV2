using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Battle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CurrentMonsterHP { get; set; }
        public virtual Monster Monster { get; set; }
        public virtual PlayerCharacter Character { get; set; }
        public virtual ICollection<BattleLog> BattleLogs { get; set; }
    }
}
