using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.W40kModel
{
    public class W40kModelEdit
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public RoleSlot RoleSlot { get; set; }
        public bool MultipleLoadouts { get; set; }
        public int PointsCost { get; set; }
        public bool IsBuilt { get; set; }
        public bool IsPainted { get; set; }
    }
}
