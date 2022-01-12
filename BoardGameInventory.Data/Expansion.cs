using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public class Expansion 
    {
        public Guid OwnerID { get; set; }
        [Key]
        public int ExpansionID { get; set; }
        [Required]
        [Display(Name ="Expansion Title")]
        public string ExpansionTitle { get; set; }
        [Required]
        [Display(Name ="Changes to Case Game")]
        public string ChangesToBase { get; set; }
       // [ForeignKey("GameID")]
        //public int GameID { get; set; }
        public virtual BoardGame Game { get; set; }
    }
}
