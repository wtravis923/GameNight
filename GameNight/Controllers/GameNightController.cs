using GameNight.Models;
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
    public class GameNightController : Controller
    {
        // GET: GameNight
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameNightService(userId);
            var model = service.GetGameTimes();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameNightCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameNightService();

            if (service.CreateGameTime(model))
            {
                TempData["SaveResult"] = "Your game was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Game could not be created.");

            return View(model);

        }

        private GameNightService CreateGameNightService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameNightService(userId);
            return service;
        }

        public ActionResult Details (int id)
        {
            var svc = CreateGameNightService();
            var model = svc.GetGameNightById(id);

            return View(model);
        }

    }
}