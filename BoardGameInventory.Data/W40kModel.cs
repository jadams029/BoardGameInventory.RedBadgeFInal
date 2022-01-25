using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public enum RoleSlot
    {
        HQ,
        Troops,
        Elites,
        FastAttack,
        HeavySupport,
        Flyer,
        DedicatedTransport,
        LordOfWar,
        Fortification
    }
    public class W40kModel
    {
        public Guid OnwerID { get; set; }
        [Key]
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public RoleSlot RoleSlot { get; set; }
        public bool MultipleLoadouts { get; set; }
        // might do what the loadout it has is.
        public int PointsCosts { get; set; }
        public bool IsBuilt { get; set; }
        public bool IsPainted { get; set; }
        //[ForeignKey("W40kArmy")]
        //public int ArmyID { get; set; }
    }
}
