using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public enum Genre { Abstract= 1, AreaControl, Deckbuilder, Dexterity, Drafting, DungeonCrawler, EngineBuilder, EuroGame, Legacy, PushYourLuck, RollAndMove, SocialDeduction, StoryTelling, WorkerPlacement, WarGame}
    public class BoardGames
    {
        [Key]
        public int GameID { get; set; }
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
