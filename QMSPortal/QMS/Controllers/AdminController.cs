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

       

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}