using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterLogin.Models
{
    [Table("Game")]
    public partial class Game
    {
        [Key] // def Primary Key (id)
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameSummary { get; set; }
        
        public ICollection<GameCollection> GameCollection { get; set; }
    }
}