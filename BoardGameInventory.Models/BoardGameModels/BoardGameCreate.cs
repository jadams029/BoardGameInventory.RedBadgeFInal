using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.BoardGameModels
{
    public class BoardGameCreate
    {
        //Tags for model validation
        [Required]
        [Display(Name ="Game Title")]
        public string GameTitle { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [Display(Name ="Number of Players")]
        public int NumberOfPlayers { get; set; }
        [Required]
        [Display(Name ="Time to play (minuetes)")]
        public int TimeToPlayMin { get; set; }
        [Required]
        [Display(Name ="Times Played")]
        public int TimesPlayed { get; set; }
        [Required]
        [Display(Name ="Expansions")]
        public bool Expansions { get; set; }
    }
}
