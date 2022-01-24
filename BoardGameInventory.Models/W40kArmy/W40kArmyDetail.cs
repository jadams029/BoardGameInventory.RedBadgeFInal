using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.W40kArmy
{
    public class W40kArmyDetail
    {
        public int ArmyID { get; set; }
        public string ArmyName { get; set; }
        public Army Army { get; set; }
        public bool CodexAvailable { get; set; }
        public bool CodexOwned { get; set; }
        //list of models with points potentially
    }
}
