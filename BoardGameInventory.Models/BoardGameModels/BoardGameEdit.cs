using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.BoardGameModels
{
    public class BoardGameEdit
    {
        [Required]
        public int GameID { get; set; }
        [Required]
        [Display(Name = "Game Title")]
        public string GameTitle { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Number Of Players")]
        public int NumberOfPlayers { get; set; }
        [Required]
        [Display(Name = "Time to Play (minutes)")]
        public int TimeToPlayMin { get; set; }
        [Required]
        [Display(Name = "Number of Times Played")]
        public int TimesPlayed { get; set; }
        [Required]
        [Display(Name = "Has Expansions?")]
        public bool Expansions { get; set; }
    }
}
