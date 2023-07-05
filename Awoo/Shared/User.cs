using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awoo.Shared
{
    public class User
    {
        [Key]
        public int Id { get; set; } = 1000;

        public string Username { get; set; } = "My User";
        public string Password { get; set; } = "My Password";
        public int Colour { get; set; } = Color.White.ToArgb();
        //public List<TabletopSession> Sessions { get; set; }


        public override string ToString()
        {
            return $"{Id}: {Username}";
        }
    }
}
