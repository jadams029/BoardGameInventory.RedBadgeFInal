using BoardGameInventory.Models.ExpansionModels;
using BoardGameInventory.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameInventory.Controllers
{
    public class ExpansionController : Controller
    {
        // GET: Expansion
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ExpansionService(userID);
            var model = service.GetExpansions();
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpansionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateExpansionService();
            if (service.CreateExpansion(model))
            {
                TempData["SaveResult"] = "Your Expansion was added to Inventory";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Expansion not added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateExpansionService();
            var model = svc.GetExpansionByID(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateExpansionService();
            var detail = service.GetExpansionByID(id);
            var model = new ExpansionEdit
            {
                ExpansionID = detail.ExpansionID,
                ExpansionTitle = detail.ExpansionTitle,
                ChangesToBase = detail.ChangesToBase
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExpansionEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ExpansionID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateExpansionService();
            if (service.UpdateExpansion(model))
            {
                TempData["SaveResult"] = "Your Expansion was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Expansion could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateExpansionService();
            var model = svc.GetExpansionByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateExpansionService();
            service.DeleteExpansion(id);
            TempData["SaveResult"] = "Your Expansion was deleted.";
            return RedirectToAction("Index");
        }
        private ExpansionService CreateExpansionService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ExpansionService(userID);
            return service;
        }
    }
}