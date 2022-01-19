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
        public string GameTitle { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public int NumberOfPlayers { get; set; }
        [Required]
        public decimal TimeToPlayHours { get; set; }
        [Required]
        public int TimesPlayed { get; set; }
        [Required]
        public bool Expansions { get; set; }
    }
}
