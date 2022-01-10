using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public class Expansions : BoardGames
    {
        [Required]
        public string ExpansionTitle { get; set; }
        [Required]
        public string ChangesToBase { get; set; }
    }
}
