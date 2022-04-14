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
    public class contratsController : Controller
    {
        private Crmcontext db = new Crmcontext();

        // GET: contrats
        public ActionResult Index()
        {
            return View(db.contrats.ToList());
        }

        // GET: contrats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }
        public ActionResult Searchcontrat(string ctt  , string cin)
        {
             
                var searchcontrat = from d in db.contrats
                             where d.idcontrat==ctt  
                             ||d.clientcin == cin
                             select d;

                return View("Searchcontrat", searchcontrat.ToList());
       
       

        }
        // GET: contrats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contrats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcontrat,idvoiture,clientcin,datecontrat,kmdepart")] contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.contrats.Add(contrat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contrat);
        }

        // GET: contrats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // POST: contrats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcontrat,idvoiture,clientcin,datecontrat,kmdepart")] contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contrat);
        }

        // GET: contrats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // POST: contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            contrat contrat = db.contrats.Find(id);
            db.contrats.Remove(contrat);
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
