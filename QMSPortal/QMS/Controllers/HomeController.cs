using QMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QMS.Controllers
{
    public class HomeController : Controller
    {
        QMS_db db = new QMS_db();

        public ActionResult Index()
        {
            String HostName = Dns.GetHostName();
            String MyIP = Dns.GetHostByName(HostName).AddressList[0].ToString();


            var ip = from r in db.IPs
                     where r.IP_Address == MyIP
                     select r.IP_Address;
            foreach (var IP in ip)
            {
                int myip = 0;
                myip = string.Compare(MyIP, IP);

                if (myip != 0)
                {
                    return RedirectToAction("Register", "Registration");
                }
                else
                {
                    return RedirectToAction("PatientSelection", "Announcement");
                }

            }
            return RedirectToAction("Register", "Registration");
        }

        public ActionResult Admin()
        {

            return RedirectToAction("Login", "Admin");
        }

        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
