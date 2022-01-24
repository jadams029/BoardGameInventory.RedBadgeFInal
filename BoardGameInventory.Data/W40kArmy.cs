using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    
        public enum Army
        {
            BlackTemplars,
            BloodAngels,
            DarkAngels,
            Deathwatch,
            GreyKnights,
            ImperialFists,
            IronHands,
            RavenGuard,
            Salamanders,
            Ultramarines,
            WhiteScars,
            AdeptaSororitas,
            AdeptusCustodes,
            AdeptusMechanicus,
            AstraMilitarum,
            ImperialKnights,
            Inquisition,
            OfficioAssassinorum,
            Daemons,
            ChaosKnights,
            ChaosSpaceMarines,
            DeathGuard,
            ThousandSons,
            Craftworlds,
            Drukhari,
            GenestealersCults,
            Harlequins,
            Necrons,
            Orks,
            TauEmpire,
            Tyranids,
            Ynnari
        }
    public class W40kArmy
    {
        public Guid OwnerID { get; set; }
        [Key]
        public int ArmyID { get; set; }
        public Army Army { get; set; }
        public string ArmyName { get; set; }
        [ForeignKey("W40KModel")]
        public int ModelID { get; set; }
        public virtual W40kModel W40KModel { get; set; }
        public bool CodexAvailable { get; set; }
        public bool CodexOwned { get; set; }


    }
}
