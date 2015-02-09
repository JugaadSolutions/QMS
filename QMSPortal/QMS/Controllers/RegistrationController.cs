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
            ViewBag.Message2=" Token No -" + Token;

            return View();

        }
        //
        // GET: /Registration/Details/5

        public ActionResult Details(int id = 0)
        {
            using (QMS_db db = new QMS_db())
            {
                Patient patient = db.Patients.Find(id);
                if (patient == null)
                {
                    return HttpNotFound();
                }
                return View(patient);
            }
        }

        //
        // GET: /Registration/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Registration/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            using (QMS_db db = new QMS_db())
            {
                if (ModelState.IsValid)
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(patient);
            }
        }

        //
        // GET: /Registration/Edit/5

        public ActionResult Edit(int id = 0)
        {
            using (QMS_db db = new QMS_db())
            {
                Patient patient = db.Patients.Find(id);
                if (patient == null)
                {
                    return HttpNotFound();
                }
                return View(patient);
            }
        }

        //
        // POST: /Registration/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                using (QMS_db db = new QMS_db())
                {
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(patient);
        }

        //
        // GET: /Registration/Delete/5

        public ActionResult Delete(int id = 0)
        {
            using (QMS_db db = new QMS_db())
            {
                Patient patient = db.Patients.Find(id);
                if (patient == null)
                {
                    return HttpNotFound();
                }
                return View(patient);
            }
        }

        //
        // POST: /Registration/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (QMS_db db = new QMS_db())
            {
                Patient patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        
    }
}