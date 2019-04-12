using GameNight.Models;
using GameNight.Services;
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
            var gameId = Guid.Parse(User.Identity.GetGameId());
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}