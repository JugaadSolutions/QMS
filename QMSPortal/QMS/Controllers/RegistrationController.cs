using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QMS.Models;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace QMS.Controllers
{
    public class RegistrationController : Controller
    {
        
        
        static Patient curpatientQentry;

        // GET: /Registration/
        [HttpGet]
        public ActionResult Register()
        {
            curpatientQentry = new Patient();
            return View(curpatientQentry);
        }
        [HttpPost]
        public ActionResult Register(Patient patientinfo)
        {

            using (QMS_db db = new QMS_db())
            {
                String HostName = Dns.GetHostName();
                db.Patients.Add(new Patient
                   {
                       PatientId = patientinfo.PatientId,
                       PatientName = patientinfo.PatientName,
                       Status = "NEW",
                       TimeStamp = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                       IP = "",

                   });

                db.SaveChanges();
            }

            using (QMS_db db = new QMS_db())
            {
                var item = (from p in db.Patients
                            where (p.PatientId == patientinfo.PatientId && p.PatientName == patientinfo.PatientName 
                            && p.Status == "NEW")
                            select p).Single();



                return RedirectToAction("Index", new { Token = item.Token });
            }

        }


        public ActionResult Index(int Token)
        {
            ViewBag.Message1 = "Registration Successfull.";
            ViewBag.Message2=" Token No  - " + Token;

            return View();

        }

        
        
    }
}