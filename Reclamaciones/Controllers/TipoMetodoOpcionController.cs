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
    public class TipoMetodoOpcionController : Controller
    {
        private ReclamacionesDbContext db = new ReclamacionesDbContext();

        // GET: TipoMetodoOpcion
        public ActionResult Index()
        {
            var tipoMetodoOpcion = db.TipoMetodoOpcion.Include(t => t.Metodo);
            return View(tipoMetodoOpcion.ToList());
        }

        // GET: TipoMetodoOpcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMetodoOpcion tipoMetodoOpcion = db.TipoMetodoOpcion.Find(id);
            if (tipoMetodoOpcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoMetodoOpcion);
        }

        // GET: TipoMetodoOpcion/Create
        public ActionResult Create()
        {
            ViewBag.MetodoId = new SelectList(db.Metodo, "Id", "Nombre");
            return View();
        }

        // POST: TipoMetodoOpcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,MetodoId")] TipoMetodoOpcion tipoMetodoOpcion)
        {
            if (ModelState.IsValid)
            {
                db.TipoMetodoOpcion.Add(tipoMetodoOpcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MetodoId = new SelectList(db.Metodo, "Id", "Nombre", tipoMetodoOpcion.MetodoId);
            return View(tipoMetodoOpcion);
        }

        // GET: TipoMetodoOpcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMetodoOpcion tipoMetodoOpcion = db.TipoMetodoOpcion.Find(id);
            if (tipoMetodoOpcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MetodoId = new SelectList(db.Metodo, "Id", "Nombre", tipoMetodoOpcion.MetodoId);
            return View(tipoMetodoOpcion);
        }

        // POST: TipoMetodoOpcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,MetodoId")] TipoMetodoOpcion tipoMetodoOpcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMetodoOpcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MetodoId = new SelectList(db.Metodo, "Id", "Nombre", tipoMetodoOpcion.MetodoId);
            return View(tipoMetodoOpcion);
        }

        // GET: TipoMetodoOpcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMetodoOpcion tipoMetodoOpcion = db.TipoMetodoOpcion.Find(id);
            if (tipoMetodoOpcion == null)
            {
                return HttpNotFound();
            }
            return View(tipoMetodoOpcion);
        }

        // POST: TipoMetodoOpcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMetodoOpcion tipoMetodoOpcion = db.TipoMetodoOpcion.Find(id);
            db.TipoMetodoOpcion.Remove(tipoMetodoOpcion);
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
