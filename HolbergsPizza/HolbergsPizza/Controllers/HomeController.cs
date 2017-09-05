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

        public ActionResult SlettBestilling(int id)
        {
            var db = new DB();
            db.Ordrer.Remove(db.Ordrer.Find(id));
            db.SaveChanges();
            return RedirectToAction("Bestillinger");
        }

        [HttpPost]
        public ActionResult Bestill(Ordre nyOrdre)
        {
            var db = new DB();
            var eksisterendeKunde = db.Kunder.FirstOrDefault(p => p.Navn.Equals(nyOrdre.Kunde.Navn));

            if (eksisterendeKunde == null)
            {
                Debug.WriteLine("Kunde eksisterer ikke");
                db.Kunder.Add(nyOrdre.Kunde);
            } else
            {
                Debug.WriteLine("Kunde eksisterer");
            }

            db.Ordrer.Add(nyOrdre);

            db.SaveChanges();

            return RedirectToAction("bestillinger");
        }
    }
}