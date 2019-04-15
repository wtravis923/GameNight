using GameNight.Models;
using GameNight.Models.GamerModels;
using GameNight.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameNight.Controllers
{
    [Authorize]
    public class GamerController : Controller
    {
        // GET: Gamer
        public ActionResult Index()
        {
            var gamerId = Guid.Parse(User.Identity.GetUserId());
            var service = new GamerService(gamerId);
            var model = service.GetGamers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GamerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGamerService();

            if (service.CreateGamer(model))
            {
                TempData["SaveResult"] = "Your gamer profile was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Gamer could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGamerService();
            var model = svc.GetGamerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGamerService();
            var detail = service.GetGamerById(id);
            var model =
                new GamerEdit
                {
                    GamerId = detail.GamerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    EmailAddress = detail.EmailAddress,
                    Location = detail.Location,
                };

            return View(model); 
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGamerService();
            var model = svc.GetGamerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGamerService();
            service.DeleteGamer(id);
            TempData["SaveResult"] = "The gamer was deleted";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GamerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GamerId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGamerService();

            if (service.UpdateGamer(model))
            {
                TempData["SaveResult"] = "Your gamer profile was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model);
        }

        private GamerService CreateGamerService()
        {
            var gamerId = Guid.Parse(User.Identity.GetUserId());
            var service = new GamerService(gamerId);
            return service;
        }
    }
}