using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMAUTO.Models;

namespace CRMAUTO1.Controllers
{
    public class voituresController : Controller
    {
        private Crmcontext db = new Crmcontext();
       
        public ActionResult getmodele()
        {
            var getmodele1 = db.modelevoitures.ToList();
            SelectList list = new SelectList(getmodele1, "idmodele", "nom_modele");
            ViewBag.mouad = list;
            return View();
        }
        public ActionResult Searchvoiture(string a , string b  , string d  )
        {

          Crmcontext crm = new Crmcontext();
        var search = from an in crm.voitures
                         where(
                      an.nomcategorie == a
                      && an.nomvoiture==b
                      
                     && an.carburant==d )
                         select an;  
            return View("Searchvoiture", search.ToList());

        }
        public ActionResult search(string a)
        {
                       
             
                var searchc = from an in db.voitures
                             where (
                           an.nomdemodele == a||an.nomcategorie==a||an.matricule==a)
                             select an;
                return View("search", searchc.ToList());
           
          
          
           
        }
        //public ActionResult search()
        //{
        //     return View("Search", db.voitures.ToList());

        //}
        // GET: voitures
        public ActionResult Index()
        {
            return View(db.voitures.ToList());
        }

        // GET: voitures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: voitures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: voitures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matricule,nomvoiture,nomdemodele,nomcategorie,kilometrage,annee,carburant,puissance,datecontrat")] voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voiture);
        }

        // GET: voitures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: voitures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matricule,nomvoiture,nomdemodele,nomcategorie,kilometrage,annee,carburant,puissance,datecontrat")] voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voiture);
        }

        // GET: voitures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            voiture voiture = db.voitures.Find(id);
            db.voitures.Remove(voiture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
