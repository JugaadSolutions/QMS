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
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        //
        // GET: /Announcement/Details/5

        public ActionResult Details(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // GET: /Announcement/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Announcement/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        //
        // GET: /Announcement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Announcement/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        //
        // GET: /Announcement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Announcement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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