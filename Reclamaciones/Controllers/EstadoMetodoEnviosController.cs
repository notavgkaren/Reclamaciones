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
    public class EstadoMetodoEnviosController : Controller
    {
        private ReclamacionesDbContext db = new ReclamacionesDbContext();

        // GET: EstadoMetodoEnvios
        public ActionResult Index()
        {
            return View(db.EstadoMetodoEnvio.ToList());
        }

        // GET: EstadoMetodoEnvios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoMetodoEnvio estadoMetodoEnvio = db.EstadoMetodoEnvio.Find(id);
            if (estadoMetodoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoMetodoEnvio);
        }

        // GET: EstadoMetodoEnvios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoMetodoEnvios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] EstadoMetodoEnvio estadoMetodoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.EstadoMetodoEnvio.Add(estadoMetodoEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoMetodoEnvio);
        }

        // GET: EstadoMetodoEnvios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoMetodoEnvio estadoMetodoEnvio = db.EstadoMetodoEnvio.Find(id);
            if (estadoMetodoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoMetodoEnvio);
        }

        // POST: EstadoMetodoEnvios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] EstadoMetodoEnvio estadoMetodoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoMetodoEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoMetodoEnvio);
        }

        // GET: EstadoMetodoEnvios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoMetodoEnvio estadoMetodoEnvio = db.EstadoMetodoEnvio.Find(id);
            if (estadoMetodoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoMetodoEnvio);
        }

        // POST: EstadoMetodoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoMetodoEnvio estadoMetodoEnvio = db.EstadoMetodoEnvio.Find(id);
            db.EstadoMetodoEnvio.Remove(estadoMetodoEnvio);
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
