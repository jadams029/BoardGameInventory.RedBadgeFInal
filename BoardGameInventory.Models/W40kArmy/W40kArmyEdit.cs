using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.W40kArmy
{
    public class W40kArmyEdit
    {
        [Required]
        public int ArmyID { get; set; }
        [Required]
        public Army Army { get; set; }
        [Required]
        public string ArmyName { get; set; }
        [Required]
        public int ModelID { get; set; }
        [Required]
        public bool CodexAvailable { get; set; }
        [Required]
        public bool CodexOwned { get; set; }
    }
}
