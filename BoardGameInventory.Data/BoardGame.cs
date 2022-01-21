using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public enum Genre
    {
        Abstract = 1,
        AreaControl,
        Deckbuilder,
        Dexterity,
        Drafting,
        DungeonCrawler,
        EngineBuilder,
        EuroGame,
        Legacy,
        PushYourLuck,
        RollAndMove,
        SocialDeduction,
        StoryTelling,
        WorkerPlacement,
        WarGame
    }
    public class BoardGame
    {
        [Key]
        public int GameID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string GameTitle { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Number of Players")]
        public int NumberOfPlayers { get; set; }
        [Required]
        [Display(Name = "Time to play in (minutes)")]
        public int TimeToPlayMin { get; set; }
        [Required]
        [Display(Name = "Time Played")]
        public int TimesPlayed { get; set; }
        [Required]
        [Display(Name = "Are there Expansions?")]
        public bool Expansions { get; set; }
        [Display(Name = "Expansions for Game")]
        public virtual List<Expansion> ExpansionsList { get; set; }
    }
}
