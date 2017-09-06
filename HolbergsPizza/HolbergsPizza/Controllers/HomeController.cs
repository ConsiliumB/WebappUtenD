using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolbergsPizza.Models;
using System.Collections;
using System.Diagnostics;

namespace HolbergsPizza.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bestillinger()
        {
            var db = new DB();

            List<Ordre> Ordrer = db.Ordrer.ToList();

            return View(Ordrer);
        }

        public ActionResult Kunder()
        {
            var db = new DB();

            List<Kunde> Kunder = db.Kunder.ToList();

            return View(Kunder);
        }

        public ActionResult SlettBestilling(int id)
        {
            var db = new DB();

            db.Ordrer.Remove(db.Ordrer.Find(id));
            db.SaveChanges();

            return RedirectToAction("Bestillinger");
        }
        public ActionResult SlettKunde(int id)
        {
            var db = new DB();

            db.Kunder.Remove(db.Kunder.Find(id));
            db.SaveChanges();

            return RedirectToAction("Kunder");
        }

        [HttpPost]
        public ActionResult Bestill(Ordre nyOrdre)
        {
            var db = new DB();
            var eksisterendeKunde = db.Kunder.FirstOrDefault(p => p.Navn.Equals(nyOrdre.Kunde.Navn));

            if (eksisterendeKunde != null)
            {
                nyOrdre.Kunde = eksisterendeKunde;
            }

            db.Ordrer.Add(nyOrdre);
            db.SaveChanges();

            return RedirectToAction("bestillinger");
        }
    }
}