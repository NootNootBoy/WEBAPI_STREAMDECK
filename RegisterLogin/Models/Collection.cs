using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterLogin.Models
{
    [Table("Collection")]
    public partial class Collection
    {
        [Key] 
        public int CollectionId { get; set; }
        public int IdUser { get; set; }
        public string CollectionName { get; set; }
        public ICollection<GameCollection> GameCollection { get; set; }
    }
}