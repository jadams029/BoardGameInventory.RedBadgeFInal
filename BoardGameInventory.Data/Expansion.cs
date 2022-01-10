using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public class Expansion : BoardGame
    {
        [Required]
        [Display(Name ="Expansion Title")]
        public string ExpansionTitle { get; set; }
        [Required]
        [Display(Name ="Changes to Case Game")]
        public string ChangesToBase { get; set; }
    }
}
