using BoardGameInventory.Models.W40kModel;
using BoardGameInventory.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameInventory.Controllers
{
    public class W40kModelController : Controller
    {
        // GET: W40kModel
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new W40kModelService(userID);
            var model = service.GetModels();
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(W40kModelCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateModelService();
            if (service.CreateModel(model))
            {
                TempData["SaveResult"] = "Your Model was Added to Inventory";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Model not added.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateModelService();
            var model = svc.GetModelByID(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateModelService();
            var detail = service.GetModelByID(id);
            var model = new W40kModelEdit
            {
                ModelID = detail.ModelID,
                ModelName = detail.ModelName,
                RoleSlot = detail.RoleSlot,
                MultipleLoadouts = detail.MultipleLoadouts,
                PointsCost = detail.PointsCost,
                IsBuilt = detail.IsBuilt,
                IsPainted = detail.IsPainted
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, W40kModelEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ModelID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateModelService();
            if (service.UpdateModel(model))
            {
                TempData["SaveResult"] = "Your Model was Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Model was not updated");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateModelService();
            var model = svc.GetModelByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateModelService();
            service.DeleteModel(id);
            TempData["SaveResult"] = "Your Model was Deleted.";
            return RedirectToAction("Index");
        }
        private W40kModelService CreateModelService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new W40kModelService(userID);
            return service;
        }
    }
}