using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.W40kArmy
{
    public class W40kArmyCreate
    {
        public Army Army { get; set; }
        public int ModelID { get; set; }
        public bool CodexAvailable { get; set; }
        public bool CodexOwned { get; set; }
    }
}
