using BoardGameInventory.Models.BoardGameModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.ExpansionModels
{
    public class ExpansionDetail 
    {
        public int ExpansionID { get; set; }
        [Display(Name = "Expansion Title")]
        public string ExpansionTitle { get; set; }
        //Might need BoardGameListItem here or both.
        public BoardGameDetail BoardGame { get; set; }
        [Display(Name = "Changes to Base Game")]
        public string ChangesToBase { get; set; }
    }
}
