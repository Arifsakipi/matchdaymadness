using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MatchdayMadness2.Controllers
{
   
    public class LiveMatchUpdatesController : Controller
    {
        private static DB db = new DB();
        private static List<LiveMatchUpdates> matchUpdates = new List<LiveMatchUpdates>();
        // GET: LiveMatchUpdatesController
        public ActionResult Index()
        {
            matchUpdates = db.LiveMatchUpdates.ToList();
            return View(matchUpdates);
        }

        // GET: LiveMatchUpdatesController/Details/5
        public ActionResult Details(int id)
        {
            var updates = db.LiveMatchUpdates.Where(x=>x.id.Equals(id)).SingleOrDefault();
            return View(updates);
        }

        // GET: LiveMatchUpdatesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiveMatchUpdatesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LiveMatchUpdates newUpdates)
        {
            {
                db.LiveMatchUpdates.Add(newUpdates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: LiveMatchUpdatesController/Edit/5
        public ActionResult Edit(int id)
        {
            var updates = db.LiveMatchUpdates.Find(id);
            return View(updates);
        }

        // POST: LiveMatchUpdatesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LiveMatchUpdates newUpdatesData)
        {
            try
            {
                var updates = db.LiveMatchUpdates.Find(newUpdatesData.id);
                if (updates != null)
                {                     
                    updates.CurrenScoreHome = newUpdatesData.CurrenScoreHome;
                    updates.CurrenScoreAway = newUpdatesData.CurrenScoreAway;
                    updates.CurrentTime = newUpdatesData.CurrentTime;
                    db.SaveChanges();   
                }else
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LiveMatchUpdatesController/Delete/5
        public ActionResult Delete(int id)
        {
            var updates = db.LiveMatchUpdates.Find(id);
            return View(updates);
        }

        // POST: LiveMatchUpdatesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var updates = db.LiveMatchUpdates.Find(id);
                if (updates != null)
                    matchUpdates.Remove(updates);
                return RedirectToAction(nameof(Index));
                db.SaveChanges();
            }
            catch
            {
                return View();
            }
        }
    }
}
