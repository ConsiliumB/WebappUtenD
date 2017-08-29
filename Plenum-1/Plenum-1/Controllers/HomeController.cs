using Plenum_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plenum_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB();
            IEnumerable<Kunde> alleKunder = db.Kunder;

            return View(alleKunder);
        }

        public ActionResult RegKunde()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegKunde(Kunde innKunde)
        {
            var db = new DB();
            db.Kunder.Add(innKunde);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult SlettKunde(int id)
        {
            var db = new DB();
            //TOO MANY BICHES
            db.Kunder.Remove(db.Kunder.Find(id));
            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}