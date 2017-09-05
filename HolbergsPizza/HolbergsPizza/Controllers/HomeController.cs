using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolbergsPizza.Models;
using System.Collections;

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
        public ActionResult Bestill(Ordre innBestilling)
        {
            var db = new DB();
            var eksisterendeKunde = db.Kunder.FirstOrDefault(p => p.Navn.Equals(innBestilling.Kunde.Navn));

            if (eksisterendeKunde == null)
            {
                Console.WriteLine("Kunde eksisterer ikke, legger til");
                eksisterendeKunde = new Kunde()
                {
                    Navn = innBestilling.Kunde.Navn,
                    Tlf = innBestilling.Kunde.Tlf,
                    Adresse = innBestilling.Kunde.Adresse
                };

                db.Kunder.Add(eksisterendeKunde);
            }

            db.Ordrer.Add(new Ordre()
            {
                Antall = innBestilling.Antall,
                Kunde = eksisterendeKunde,
                Type = innBestilling.Type,
                Tykkelse = innBestilling.Tykkelse
            });

            db.SaveChanges();

            return RedirectToAction("bestillinger");
        }
    }
}