using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.BoardGameModels
{
    public class BoardGameListItem
    {
        [Display(Name ="Game ID #")]
        public int GameID { get; set; }
        [Display(Name ="Game Title")]
        public string GameTitle { get; set; }
    }
}
