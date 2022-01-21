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
        [Display(Name ="Area Control")]
        AreaControl,
        Deckbuilder,
        Dexterity,
        Drafting,
        [Display(Name ="Dungeon Crawler")]
        DungeonCrawler,
        [Display(Name ="Engine Builder")]
        EngineBuilder,
        [Display(Name ="Euro Game")]
        EuroGame,
        Legacy,
        [Display(Name ="Push Your Luck")]
        PushYourLuck,
        [Display(Name ="Roll And Move")]
        RollAndMove,
        [Display(Name ="Social Deduction")]
        SocialDeduction,
        [Display(Name ="Story Telling")]
        StoryTelling,
        [Display(Name ="Worker Placement")]
        WorkerPlacement,
        [Display(Name ="War Game")]
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
