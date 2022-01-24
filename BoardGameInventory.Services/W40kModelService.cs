using BoardGameInventory.Data;
using BoardGameInventory.Models.W40kModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Services
{
    public class W40kModelService
    {
        private readonly Guid _userID;
        public W40kModelService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateModel(W40kModelCreate model)
        {
            var entity = new W40kModel
            {
                OnwerID = _userID,
                ModelName = model.ModelName,
                RoleSlot = model.RoleSlot,
                MultipleLoadouts = model.MultipleLoadouts,
                PointsCosts = model.PointsCost,
                IsBuilt = model.IsBuilt,
                IsPainted = model.IsPainted
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.W40KModels.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<W40kModelListItem> GetModels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.W40KModels.Where(e => e.OnwerID == _userID).Select(e => new W40kModelListItem
                {
                    ModelID = e.ModelID,
                    ModelName = e.ModelName
                });
                return query.ToArray();
            }
        }
        public W40kModelDetail GetModelByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.W40KModels.Single(e => e.ModelID == id && e.OnwerID == _userID);
                return new W40kModelDetail
                {
                    ModelID = entity.ModelID,
                    ModelName = entity.ModelName,
                    RoleSlot = entity.RoleSlot,
                    MultipleLoadouts = entity.MultipleLoadouts,
                    PointsCost = entity.PointsCosts,
                    IsBuilt = entity.IsBuilt,
                    IsPainted = entity.IsPainted
                };
            }
        }
        public bool UpdateModel(W40kModelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.W40KModels.Single(e => e.ModelID == model.ModelID && e.OnwerID == _userID);
                entity.ModelName = model.ModelName;
                entity.RoleSlot = model.RoleSlot;
                entity.MultipleLoadouts = model.MultipleLoadouts;
                entity.PointsCosts = model.PointsCost;
                entity.IsBuilt = model.IsBuilt;
                entity.IsPainted = model.IsPainted;

                return ctx.SaveChanges() == 1;
            }            
        }
        public bool DeleteModel(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.W40KModels.Single(e => e.ModelID == id && e.OnwerID == _userID);
                ctx.W40KModels.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
