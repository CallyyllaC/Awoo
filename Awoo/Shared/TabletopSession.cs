using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awoo.Shared
{
    public class TabletopSession
    {
        [Key]
        public int Id { get; set; } = 1000;

        public string Name { get; set; }
        public User GameMaster { get; set; }
        public TTRPG Game { get; set; }
        public List<User> Players { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        [ForeignKey("GameMaster")]
        public int GameMasterId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:u}")]
        public DateTime? NextSession { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
