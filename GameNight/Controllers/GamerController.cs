using GameNight.Models;
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
            var model = new GamerListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}