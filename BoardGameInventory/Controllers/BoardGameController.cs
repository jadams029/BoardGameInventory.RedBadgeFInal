using BoardGameInventory.Models.BoardGameModels;
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
    public class BoardGameController : Controller
    {
        // GET: BoardGame
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BoardGameService(userID);
            var model = service.GetBoardGames();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoardGameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBoardGameService();
            if (service.CreateBoardGame(model))
            {
                TempData["SaveResult"] = "Your Board Game was Added to Inventory.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Board Game not added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateBoardGameService();
            var model = svc.GetBoardGameByID(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateBoardGameService();
            var detail = service.GetBoardGameByID(id);
            var model = new BoardGameEdit
            {
                GameID = detail.GameID,
                GameTitle = detail.GameTitle,
                Genre = detail.Genre,
                NumberOfPlayers = detail.NumberOfPlayers,
                TimeToPlayHours = detail.TimeToPlayHours,
                TimesPlayed = detail.TimesPlayed,
                Expansions = detail.Expansions
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BoardGameEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.GameID != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }
            var service = CreateBoardGameService();
            if (service.UpdateBoardGame(model))
            {
                TempData["SaveResult"] = "Your Board Game was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your board game could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBoardGameService();
            var model = svc.GetBoardGameByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBoardGameService();
            service.DeleteBoardGame(id);
            TempData["SaveResult"] = "Your Board Game was Deleted.";
            return RedirectToAction("Index");
        }
        private BoardGameService CreateBoardGameService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BoardGameService(userID);
            return service;
        }
    }
}