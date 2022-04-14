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
    public class ModelevoituresController : Controller
    {
        private Crmcontext db = new Crmcontext();

        // GET: Modelevoitures1
        public ActionResult Index()
        {
            return View(db.modelevoitures.ToList());
        }

        // GET: Modelevoitures1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelevoiture modelevoiture = db.modelevoitures.Find(id);
            if (modelevoiture == null)
            {
                return HttpNotFound();
            }
            return View(modelevoiture);
        }

        // GET: Modelevoitures1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modelevoitures1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmodele,Nom_modele,Nom_categorie,puissance")] Modelevoiture modelevoiture)
        {
            if (ModelState.IsValid)
            {
                db.modelevoitures.Add(modelevoiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelevoiture);
        }

        // GET: Modelevoitures1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelevoiture modelevoiture = db.modelevoitures.Find(id);
            if (modelevoiture == null)
            {
                return HttpNotFound();
            }
            return View(modelevoiture);
        }

        // POST: Modelevoitures1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmodele,Nom_modele,Nom_categorie,puissance")] Modelevoiture modelevoiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelevoiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelevoiture);
        }

        // GET: Modelevoitures1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelevoiture modelevoiture = db.modelevoitures.Find(id);
            if (modelevoiture == null)
            {
                return HttpNotFound();
            }
            return View(modelevoiture);
        }

        // POST: Modelevoitures1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelevoiture modelevoiture = db.modelevoitures.Find(id);
            db.modelevoitures.Remove(modelevoiture);
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
