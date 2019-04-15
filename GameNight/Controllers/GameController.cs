using GameNight.Models;
using GameNight.Models.GameModels;
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
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var gameId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(gameId);
            var model = service.GetGames();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Game could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var detail = service.GetGameById(id);
            var model =
                new GameEdit
                {
                    GameId = detail.GameId,
                    Title = detail.Title,
                    Genre = detail.Genre,
                    PlayerCount = detail.PlayerCount
                };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGameService();
            service.DeleteGame(id);
            TempData["SaveResult"] = "The gamer was deleted";
            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }

        private GameService CreateGameService()
        {
            var gameId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(gameId);
            return service;
        }
    }
}