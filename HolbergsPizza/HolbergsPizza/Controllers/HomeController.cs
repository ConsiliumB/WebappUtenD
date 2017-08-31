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
            IEnumerable<Bestilling> bestillinger = db.Bestillinger;
            return View(bestillinger);
        }

        [HttpPost]
        public ActionResult Bestill(Bestilling innBestilling)
        {
            var db = new DB();
            var eksisterendeKunde = db.Kunder.Where(p => p.Navn.Equals(innBestilling.Navn));
            
            if (eksisterendeKunde.Count() < 1)
            {
                Console.WriteLine("Kunde eksisterer, legger til");
                var nyKunde = new Kunde()
                {
                    Navn = innBestilling.Navn,
                    Tlf = innBestilling.Tlf,
                    Adresse = innBestilling.Adresse
                };

                db.Kunder.Add(nyKunde);
            }

            Console.WriteLine("Bestilling legges til");
            db.Bestillinger.Add(innBestilling);

            db.SaveChanges();

            return RedirectToAction("bestillinger");
        }
    }
}