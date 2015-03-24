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
            if (model != null)
            {
                foreach (var user1 in model)
                {
                    return RedirectToAction("Admin");
                }
            }

            return RedirectToAction("Login", "Admin");

        }
        [HttpGet]
        public ActionResult Admin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Admin(int id)
        {
            if (id == 1)
            {
                return View("TokenSetting");
            }
            if (id == 2)
            {
                return View("IpSetting");
            }
            return View();
        }
        [HttpGet]
        public ActionResult TokenSetting()
        {
            Config config = new Config();
            return View(config);
        }
        [HttpPost]
        public ActionResult TokenSetting(Config token)
        {
            Config config = new Config();

            var tokenvalue = (from r in db.Configs
                              where r.key == "Token"
                              select r).Single();
            tokenvalue.Value = token.Value;


            db.SaveChanges();


            return RedirectToAction("Index", new { token = token.Value });
        }
        public ActionResult Index(int token)
        {
            ViewBag.Message = "Token has been reset to " + token;
            return View();
        }
        [HttpGet]
        public ActionResult IpSetting()
        {
           
            return View(db.IPs.ToList());
        }
        [HttpPost]
        public ActionResult IpSetting(IP  ip)
        {
            var Ip = from r in db.IPs
                     select r;
            foreach (var item in Ip)
            {
                item.IP_Address = ip.IP_Address;
                db.SaveChanges();
            }
            return RedirectToAction("IPSettingMsg");
        }
        //
        // GET: /Admin/Details/5

        public ActionResult IPSettingMsg()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}