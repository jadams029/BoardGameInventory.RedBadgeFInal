using BoardGameInventory.Data;
using BoardGameInventory.Models.RPGBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Services
{
    class RPGBookService
    {
        private readonly Guid _userID;
        public RPGBookService (Guid userID)
        {
            _userID = userID;
        }
        public bool CreateRPGBook(RPGBookCreate model)
        {
            var entity = new RPGBook()
            {
                OwnerID = model.OwnerID,
                BookTitle = model.BookTitle,
                RPGSystem = model.RPGSystem,
                BookType = model.BookType
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RPGBooks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RPGBookListItem> GetRPGBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.RPGBooks.Where(e => e.OwnerID == _userID).Select(e => new RPGBookListItem
                {
                    BookID = e.BookID,
                    BookTitle = e.BookTitle
                });
                return query.ToArray();
            }
        }
        public RPGBookDetail GetRPGBookByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RPGBooks.Single(e => e.BookID == id && e.OwnerID == _userID);
                return new RPGBookDetail
                {
                    BookTitle = entity.BookTitle,
                    BookType = entity.BookType,
                    RPGSystem = entity.RPGSystem
                };                
            }
        }
        public bool UpdateRPGBook(RPGBookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RPGBooks.Single(e => e.BookID == model.BookID && e.OwnerID == _userID);

                entity.BookTitle = model.BookTitle;
                entity.BookType = model.BookType;
                entity.RPGSystem = model.RPGSystem;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRPGBook(int bookID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RPGBooks.Single(e => e.BookID == bookID && e.OwnerID == _userID);
                ctx.RPGBooks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
