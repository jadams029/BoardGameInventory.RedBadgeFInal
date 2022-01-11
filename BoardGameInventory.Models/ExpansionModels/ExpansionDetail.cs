using BoardGameInventory.Models.BoardGameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.ExpansionModels
{
    public class ExpansionDetail 
    {
        public int ExpansionID { get; set; }
        public string ExpansionTitle { get; set; }
        //Might need BoardGameListItem here or both.
        public BoardGameDetail BoardGame { get; set; }
        public string ChangesToBase { get; set; }
    }
}
