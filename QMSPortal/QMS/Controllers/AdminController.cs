using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QMS.Models;

namespace QMS.Controllers
{
    public class AdminController : Controller
    {
        private QMS_db db = new QMS_db();

        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }
        
        [HttpPost]
        public ActionResult Login(User user)
        {
            var model = from r in db.Users
                        where r.Name == user.Name && r.Password == user.Password
                        select r;
            if(model!=null)
            {
                foreach (var user1 in model)
                {
                    return RedirectToAction("TokenSetting");
                }
            }
            
            return RedirectToAction("Login", "Admin");

        }

        [HttpGet]
        public  ActionResult TokenSetting()
        {
            Config config = new Config();
            return View(config);
        }
        [HttpPost]
        public ActionResult TokenSetting(Config token)
        {
            Config config = new Config();
            
                var tokenvalue = (from r in db.Configs
                                   where r.key=="Token"
                                   select r).Single();
                tokenvalue.Value = token.Value;
                

                db.SaveChanges();

                return RedirectToAction("Index", new {token=token.Value });
        }
        public ActionResult Index(int token)
        {
            ViewBag.Message = "Token has been reset to " + token;
            return View();
        }
        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}