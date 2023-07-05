using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Awoo.Shared
{
    public class TTRPG
    {
        [Key]
        public int Id { get; set; } = 1000;
        public string Name { get; set; } = "My Game";
        public int Colour { get; set; } = Color.White.ToArgb();
        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
