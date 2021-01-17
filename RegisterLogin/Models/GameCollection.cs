using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterLogin.Models
{
    [Table("GameCollection")]
    public class GameCollection
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}