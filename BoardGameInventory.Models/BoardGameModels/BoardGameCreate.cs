using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.BoardGameModels
{
    public class BoardGameCreate
    {
        public string GameTitle { get; set; }
        public Genre Genre { get; set; }
        public int NumberOfPlayers { get; set; }
        public decimal TimeToPlayHours { get; set; }
        public int TimesPlayed { get; set; }
        public bool Expansions { get; set; }
    }
}
