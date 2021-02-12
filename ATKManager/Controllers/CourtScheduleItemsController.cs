using ATKManager.Models;
using ATKManager.Security;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ATKManager.Controllers
{
    public class CourtScheduleItemsController : Controller
    {
        private AppDbContext db= null;
        public CourtScheduleItemsController(AppDbContext db)
        {
            this.db = db;
            
        }

     
        public ActionResult Index()
        {
            //db.Configuration.LazyLoadingEnabled = false;
            return View(db.CourtScheduleItem.Include("Court").ToList().OrderByDescending(x => x.TimeTableID));
        }
        public ActionResult Create()
        {
            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var typ = userID.GetType();

            ViewBag.CourtID = new SelectList(db.Courts, "CourtID", "CourtName");
            ViewData["userID"] = userID;
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourtScheduleItem crt)
        {

            db.CourtScheduleItem.Add(crt);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult Calendar()
        {
            return View();
        }

        //public JsonResult GetEvents()
        //{

        //        var events = db.FullCalendars.ToList();
        //        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        //}







        [HttpPost()]
        public ActionResult Create(string saat, string kort)
        {

            string json =("Create/CourtClass?saat=" + saat + "&kort=" + kort);
            var t = JsonConvert.DeserializeObject(json);
            return Json(t, System.Web.Mvc.JsonRequestBehavior.AllowGet);

            //var t = JsonConvert.DeserializeObject<MessageResult>(json);

            //if (t != null)
            //    return Json("başarılı");
            //else
            //    return Json("başarısız");

        }









        public ActionResult CalendarItem()
        {
            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var typ = userID.GetType();

            ViewBag.CourtID = new SelectList(db.Courts, "CourtID", "CourtName");
            ViewData["userID"] = userID;
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CalendarItem(CourtScheduleItem crt)
        {

            db.CourtScheduleItem.Add(crt);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
           
            var b = db.CourtScheduleItem.Where(x => x.TimeTableID == id).SingleOrDefault();
         
            ViewBag.CourtID = new SelectList(db.Courts, "CourtID", "CourtName", b.CourtID);
            return View(b);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Edit(int id, CourtScheduleItem crt)
        {
            if (ModelState.IsValid)
            {
                var b = db.CourtScheduleItem.Where(x => x.CourtID == id).SingleOrDefault();
                
                b.ReservationDate = crt.ReservationDate;
      
                b.CourtID = crt.CourtID;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(crt);
        }

    }
}







//public ActionResult Create()
//{
//    var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
//    var typ = userID.GetType();

//    ViewBag.CourtID = new SelectList(db.Courts, "CourtID", "CourtName");
//    ViewData["userID"] = userID;
//    return View();
//}
//[HttpPost]
////[ValidateInput(false)]
//[ValidateAntiForgeryToken]
//public ActionResult Create(CourtScheduleItem crt)
//{

//    db.CourtScheduleItem.Add(crt);
//    db.SaveChanges();
//    return RedirectToAction("Create");
//}