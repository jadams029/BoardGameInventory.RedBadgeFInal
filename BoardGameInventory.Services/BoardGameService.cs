using BoardGameInventory.Data;
using BoardGameInventory.Models.BoardGameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Services
{
    public class BoardGameService
    {
        private readonly Guid _userID;
        public BoardGameService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateBoardGame(BoardGameCreate model)
        {
            var entity = new BoardGame()
            {
                OwnerID = _userID,
                GameTitle = model.GameTitle,
                Genre = model.Genre,
                NumberOfPlayers = model.NumberOfPlayers,
                TimeToPlayHours = model.TimeToPlayHours,
                TimesPlayed = model.TimesPlayed,
                Expansions = model.Expansions
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BoardGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BoardGameListItem> GetBoardGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.BoardGames.Where(e => e.OwnerID == _userID).Select(e => new BoardGameListItem
                {
                    GameID = e.GameID,
                    GameTitle = e.GameTitle
                });
                return query.ToArray();
            }
        }
        public BoardGameDetail GetBoardGameByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.BoardGames.Single(e => e.GameID == id && e.OwnerID == _userID);
                return new BoardGameDetail
                {
                    GameID = entity.GameID,
                    GameTitle = entity.GameTitle,
                    Genre = entity.Genre,
                    NumberOfPlayers = entity.NumberOfPlayers,
                    TimeToPlayHours = entity.TimeToPlayHours,
                    TimesPlayed = entity.TimesPlayed,
                    Expansions = entity.Expansions,
                    //ListOfExpanions = entity.ExpansionsList.Select
                    
                };
            }
        }
        public bool UpdateBoardGame(BoardGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.BoardGames.Single(e => e.GameID == model.GameID && e.OwnerID == _userID);

                entity.GameTitle = model.GameTitle;
                entity.Genre = model.Genre;
                entity.NumberOfPlayers = model.NumberOfPlayers;
                entity.TimeToPlayHours = model.TimeToPlayHours;
                entity.TimesPlayed = model.TimesPlayed;
                entity.Expansions = model.Expansions;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBoardGame(int gameid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.BoardGames.Single(e => e.GameID == gameid && e.OwnerID == _userID);
                ctx.BoardGames.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
