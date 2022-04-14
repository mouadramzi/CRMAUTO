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
    public class FacturesController : Controller
    {
        private Crmcontext db = new Crmcontext();
        public ActionResult searchfacture(string idclient, string idf)
        {
            var search = from d in db.factures
                         where d.cin == idclient||d.idfacture==idf
                      
                         select d;

            return View("searchfacture", search.ToList());

        }
        public ActionResult reporting(string id)
        {



            var searchf = from d in db.factures
                         where   d.idfacture == id

                         select d;

            return View("reporting", searchf.ToList());

        }

        // GET: Factures
        public ActionResult Index()
        {
            return View(db.factures.ToList());
        }

        // GET: Factures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.factures.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfacture,cin,Montant,modele,categorie")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.factures.Add(facture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.factures.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfacture,cin,Montant,modele,categorie")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.factures.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Facture facture = db.factures.Find(id);
            db.factures.Remove(facture);
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
