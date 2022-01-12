using BoardGameInventory.Models.RPGBookModels;
using BoardGameInventory.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameInventory.Controllers
{
    [Authorize]
    public class RPGBookController : Controller
    {
        // GET: RPGBook
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RPGBookService(userID);
            var model = service.GetRPGBooks();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RPGBookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRPGBookService();
            if (service.CreateRPGBook(model))
            {
                TempData["SaveResult"] = "Your RPG Book was added to Inventory.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "RPG Book not added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateRPGBookService();
            var model = svc.GetRPGBookByID(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateRPGBookService();
            var detail = service.GetRPGBookByID(id);
            var model = new RPGBookEdit()
            {
                BookID = detail.BookID,
                BookTitle = detail.BookTitle,
                BookType = detail.BookType,
                RPGSystem = detail.RPGSystem
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RPGBookEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.BookID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateRPGBookService();
            if (service.UpdateRPGBook(model))
            {
                TempData["SaveResult"] = "Your RPG Book was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your RPG Book could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRPGBookService();
            var model = svc.GetRPGBookByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRPGBookService();
            service.DeleteRPGBook(id);
            TempData["SaveResult"] = "Your RPG Book was Deleted.";
            return RedirectToAction("Index");
        }
        private RPGBookService CreateRPGBookService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RPGBookService(userID);
            return service;
        }
    }
}