using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reclamaciones.Models;

namespace Reclamaciones.Controllers
{
    public class MetodoController : Controller
    {
        private ReclamacionesDbContext db = new ReclamacionesDbContext();

        // GET: Metodo
        public ActionResult Index()
        {
            return View(db.Metodo.ToList());
        }

        // GET: Metodo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodo metodo = db.Metodo.Find(id);
            if (metodo == null)
            {
                return HttpNotFound();
            }
            return View(metodo);
        }

        // GET: Metodo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metodo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Metodo metodo)
        {
            if (ModelState.IsValid)
            {
                db.Metodo.Add(metodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodo);
        }

        // GET: Metodo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodo metodo = db.Metodo.Find(id);
            if (metodo == null)
            {
                return HttpNotFound();
            }
            return View(metodo);
        }

        // POST: Metodo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Metodo metodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodo);
        }

        // GET: Metodo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodo metodo = db.Metodo.Find(id);
            if (metodo == null)
            {
                return HttpNotFound();
            }
            return View(metodo);
        }

        // POST: Metodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Metodo metodo = db.Metodo.Find(id);
            db.Metodo.Remove(metodo);
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
