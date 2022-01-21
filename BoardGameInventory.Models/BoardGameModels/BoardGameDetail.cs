using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.BoardGameModels
{
    public class BoardGameDetail
    {
        public int GameID { get; set; }
        [Display(Name ="Game Title")]
        public string GameTitle { get; set; }
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
        [Display(Name = "Number Of Players")]
        public int NumberOfPlayers { get; set; }
        [Display(Name = "Time to Play (minutes)")]//Might change to minutes
        public int TimeToPlayMin { get; set; }
        [Display(Name = "Number of Times Played")]
        public int TimesPlayed { get; set; }
        [Display(Name = "Has Expansions?")]
        public bool Expansions { get; set; }
    }
}
