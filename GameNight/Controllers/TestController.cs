using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameNight.Data;

namespace GameNight.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Test
        public ActionResult Index()
        {
            return View(db.GameTimes.ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameTime gameTime = db.GameTimes.Find(id);
            if (gameTime == null)
            {
                return HttpNotFound();
            }
            return View(gameTime);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameTimeId,OwnerId,Game,DateTime,Location,NumberOfPlayers,Openings,NoobsAllowed,Description,TutorialVideo")] GameTime gameTime)
        {
            if (ModelState.IsValid)
            {
                db.GameTimes.Add(gameTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameTime);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameTime gameTime = db.GameTimes.Find(id);
            if (gameTime == null)
            {
                return HttpNotFound();
            }
            return View(gameTime);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameTimeId,OwnerId,Game,DateTime,Location,NumberOfPlayers,Openings,NoobsAllowed,Description,TutorialVideo")] GameTime gameTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameTime);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameTime gameTime = db.GameTimes.Find(id);
            if (gameTime == null)
            {
                return HttpNotFound();
            }
            return View(gameTime);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameTime gameTime = db.GameTimes.Find(id);
            db.GameTimes.Remove(gameTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
