using BoardGameInventory.Data;
using BoardGameInventory.Models.BoardGameModels;
using BoardGameInventory.Models.ExpansionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Services
{
    public class ExpansionService
    {
        private readonly Guid _userID;
        public ExpansionService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateExpansion(ExpansionCreate model)
        {
            var entity = new Expansion()
            {
                OwnerID = _userID,
                GameID = model.GameID,
                ExpansionTitle = model.ExpansionTitle,
                ChangesToBase = model.ChangesToBase
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Expansions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ExpansionListItem> GetExpansions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Expansions.Where(e => e.OwnerID == _userID).Select(e => new ExpansionListItem
                {
                    ExpansionID = e.ExpansionID,
                    ExpansionTitle = e.ExpansionTitle
                });
                return query.ToArray();
            }
        }
        public ExpansionDetail GetExpansionByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Expansions.Single(e => e.ExpansionID == id && e.OwnerID == _userID);
                return new ExpansionDetail
                {
                    ExpansionID = entity.ExpansionID,
                    ExpansionTitle = entity.ExpansionTitle,
                    BoardGame = new BoardGameDetail()
                    {
                        GameID = entity.GameID,
                        GameTitle = entity.Game.GameTitle,
                        Genre = entity.Game.Genre,
                        NumberOfPlayers = entity.Game.NumberOfPlayers,
                        TimeToPlayHours = entity.Game.TimeToPlayHours,
                        Expansions = entity.Game.Expansions

                    },
                    ChangesToBase = entity.ChangesToBase
                    //add times played for the expansion where all needed(expansion class, models and updated parts in the services)
                };
            }
        }
        public bool UpdateExpansion(ExpansionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Expansions.Single(e => e.ExpansionID == model.ExpansionID && e.OwnerID == _userID);

                entity.ExpansionTitle = model.ExpansionTitle;
                entity.ChangesToBase = model.ChangesToBase;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteExpansion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Expansions.Single(e => e.ExpansionID == id && e.OwnerID == _userID);
                ctx.Expansions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
