using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.W40kArmy
{
    public class W40kArmyCreate
    {
        [Required]
        [Display(Name ="Army Name")]
        public string ArmyName { get; set; }
        [Required]
        [Display(Name ="Army")]
        public Army Army { get; set; }
        //[Display(Name ="Models")]
        //[Required]
        public int ModelID { get; set; }
        [Required]
        [Display(Name ="Codex Available")]
        public bool CodexAvailable { get; set; }
        [Required]
        [Display(Name ="Codex Owned")]
        public bool CodexOwned { get; set; }
    }
}
