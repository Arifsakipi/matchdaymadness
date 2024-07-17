using MatchdayMadness2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchdayMadness2.Controllers
{
    public class UserController : Controller
    {
        private static DB db = new DB();
        private static List<User> users = new List<User>();
        // GET: UserController
        public ActionResult Index()
        {
            users = db.Users.ToList();  
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = db.Users.Where(x => x.id.Equals(id)).SingleOrDefault();
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User newUser)
        {
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User userNewData)
        {
            try
            {
                var user = db.Users.Find(userNewData.id);
                if (user != null)
                {
                    user.username = userNewData.username;
                    user.email = userNewData.email;
                    user.password = userNewData.password;
                    user.phoneNumber = userNewData.phoneNumber;
                    user.dateOfBirth = userNewData.dateOfBirth;
                    db.SaveChanges();
                } else
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id) 
        {
            try
            {
                var user = db.Users.Find(id);
                if (user != null)
                    users.Remove(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
