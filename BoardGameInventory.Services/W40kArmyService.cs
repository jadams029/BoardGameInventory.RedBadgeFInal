using BoardGameInventory.Data;
using BoardGameInventory.Models.W40kArmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Services
{
    public class W40kArmyService
    {
        private readonly Guid _userID;
        public W40kArmyService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateArmy(W40kArmyCreate model)
        {
            var entity = new W40kArmy()
            {
                OwnerID = _userID,
                ArmyName = model.ArmyName,
                Army = model.Army,
                ModelID = model.ModelID,
                CodexAvailable = model.CodexAvailable,
                CodexOwned = model.CodexOwned
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.W40KArmies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<W40kArmyListItem> GetArmies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.W40KArmies.Where(e => e.OwnerID == _userID).Select(e => new W40kArmyListItem
                {
                    ArmyID = e.ArmyID,
                    ArmyName = e.ArmyName
                });
                return query.ToArray();
            }
        }
        public W40kArmyDetail GetArmybyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.W40KArmies.Single(e => e.ArmyID == id && e.OwnerID == _userID);
                return new W40kArmyDetail
                {
                    ArmyID = entity.ArmyID,
                    ArmyName = entity.ArmyName,
                    Army = entity.Army,
                    CodexAvailable = entity.CodexAvailable,
                    CodexOwned = entity.CodexOwned
                };
            }
        }
        public bool UpdateArmy(W40kArmyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.W40KArmies.Single(e => e.ArmyID == model.ArmyID && e.OwnerID == _userID);
                entity.ArmyName = model.ArmyName;
                entity.Army = model.Army;
                entity.CodexAvailable = model.CodexAvailable;
                entity.CodexOwned = model.CodexOwned;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteArmy(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.W40KArmies.Single(e => e.ArmyID == id && e.OwnerID == _userID);
                ctx.W40KArmies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
