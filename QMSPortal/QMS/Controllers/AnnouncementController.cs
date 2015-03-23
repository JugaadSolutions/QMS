using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QMS.Models;
using System.Net;

namespace QMS.Controllers
{
    public class AnnouncementController : Controller
    {
        private QMS_db db = new QMS_db();

        //
        // GET: /Announcement/
       

       
        
        public ActionResult PatientSelection()
        {
            Response.AddHeader("Refresh", "5");
            int model = 0;
            model = (from r in db.Patients
                     where r.Status == "NEW" || r.Status == "MISSED"
                     select r.PatientName).Count();

            ViewBag.Message = "No.Of Patients=" + model;
            ViewBag.No_of_Pateints = model;
            return View();
        }
        [HttpGet]
        public ActionResult Announce()
        {
            
            Patient curPatient = new Patient();

            var model = from r in db.Patients
                        where r.Status == "NEW" || r.Status == "MISSED"
                        orderby r.TimeStamp
                        select r;
            model.Take(1);
            foreach (var item in model)
            {
                return View(item);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Announce( String Command,Patient P)
        {
            String HostName = Dns.GetHostName();
            String MyIP = Dns.GetHostByName(HostName).AddressList[0].ToString();
            Patient curPatient = new Patient();
            
            var Patientinfo = (from r in db.Patients
                               where r.PatientId == P.PatientId
                               select r).Single();
            if ((Patientinfo.Status == "NEW"|| Patientinfo.Status=="MISSED") && Command!="CALL")
                return View(Patientinfo);
            Patientinfo.Status = Command;
            db.SaveChanges();
            Patientinfo.IP = MyIP;
            db.SaveChanges();
            Patientinfo.TimeStamp = DateTime.Now;
            db.SaveChanges();
            ModelState.Clear();
            if (Command != "CALL")
            {
                return RedirectToAction("PatientSelection");
            }
            return View(Patientinfo);

        }
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}