using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.ExpansionModels
{
    public class ExpansionCreate : BoardGameModels.BoardGameCreate
    {
        public string ExpansionTitle { get; set; }
        public string ChangesToBase { get; set; }
    }
}
