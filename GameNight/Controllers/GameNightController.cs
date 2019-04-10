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

        public ActionResult Edit(int id)
        {
            var service = CreateGameNightService();
            var detail = service.GetGameNightById(id);
            var model =
                new GameNightEdit
                {
                    GameTimeId = detail.GameTimeId,
                    Game = detail.Game,
                    DateTime = detail.DateTime,
                    Location = detail.Location,
                    NumberOfPlayers = detail.NumberOfPlayers,
                    Openings = detail.Openings,
                    NoobsAllowed = detail.NoobsAllowed,
                    Description = detail.Description,
                    TutorialVideo = detail.TutorialVideo
                };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameNightService();
            var model = svc.GetGameNightById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGameTime(int id)
        {
            var service = CreateGameNightService();
            service.DeleteGameTime(id);
            TempData["SaveResult"] = "GameTime successfully deleted.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameNightEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GameTimeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameNightService();

            if (service.UpdateGameNight(model))
            {
                TempData["SaveResult"] = "Your GameTime was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your GameTime could not be updated. Try again.");

            return View();
        }

    }
}