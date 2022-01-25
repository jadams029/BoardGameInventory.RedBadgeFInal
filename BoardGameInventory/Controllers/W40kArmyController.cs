using BoardGameInventory.Models.W40kArmy;
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
    public class W40kArmyController : Controller
    {
        // GET: W40kArmy
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new W40kArmyService(userID);
            var model = service.GetArmies();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(W40kArmyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateModelService();
            if (service.CreateArmy(model))
            {
                TempData["SaveResult"] = "Your Army was Added to Inventory";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Army not added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateModelService();
            var model = svc.GetArmybyID(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateModelService();
            var detail = service.GetArmybyID(id);
            var model = new W40kArmyEdit
            {
                ArmyID = detail.ArmyID,
                ArmyName = detail.ArmyName,
                Army = detail.Army,
                //ModelID/list of models
                CodexAvailable = detail.CodexAvailable,
                CodexOwned = detail.CodexOwned
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, W40kArmyEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ModelID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateModelService();
            if (service.UpdateArmy(model))
            {
                TempData["SaveResult"] = "Your Army was Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Army was not Updated");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateModelService();
            var model = svc.GetArmybyID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateModelService();
            service.DeleteArmy(id);
            TempData["SaveResult"] = "Your Army was Deleted.";
            return RedirectToAction("Index");
        }
        private W40kArmyService CreateModelService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new W40kArmyService(userID);
            return service;
        }
    }
}