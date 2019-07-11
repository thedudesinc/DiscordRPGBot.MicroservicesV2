using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class BattleLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Log { get; set; }
        public virtual Battle Battle { get; set; }

    }
}
