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
    public class ReclamacionesController : Controller
    {
        private ReclamacionesDbContext db = new ReclamacionesDbContext();

        // GET: Reclamaciones
        public ActionResult Index()
        {
            var metodoEnvio = db.MetodoEnvio.Include(m => m.Cliente).Include(m => m.Departamento).Include(m => m.EstadoMetodoEnvio).Include(m => m.TipoMetodoOpcion).Where(x => x.TipoMetodoOpcion.MetodoId == 2);
            return View(metodoEnvio.ToList());
        }

        // GET: Reclamaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoEnvio metodoEnvio = db.MetodoEnvio.Find(id);
            if (metodoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(metodoEnvio);
        }

        // GET: Reclamaciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre");
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre");
            ViewBag.EstadoMetodoEnvioId = new SelectList(db.EstadoMetodoEnvio, "Id", "Nombre");
            ViewBag.TipoMetodoOpcionId = new SelectList(db.TipoMetodoOpcion.Where(x => x.MetodoId == 2), "Id", "Nombre");
            return View();
        }

        // POST: Reclamaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoMetodoOpcionId,DepartamentoId,FechaInicio,HoraInicio,EstadoMetodoEnvioId,ClienteId")] MetodoEnvio metodoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.MetodoEnvio.Add(metodoEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre", metodoEnvio.ClienteId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre", metodoEnvio.DepartamentoId);
            ViewBag.EstadoMetodoEnvioId = new SelectList(db.EstadoMetodoEnvio, "Id", "Nombre", metodoEnvio.EstadoMetodoEnvioId);
            ViewBag.TipoMetodoOpcionId = new SelectList(db.TipoMetodoOpcion.Where(x => x.MetodoId == 2), "Id", "Nombre", metodoEnvio.TipoMetodoOpcionId);
            return View(metodoEnvio);
        }

        // GET: Reclamaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoEnvio metodoEnvio = db.MetodoEnvio.Find(id);
            if (metodoEnvio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre", metodoEnvio.ClienteId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre", metodoEnvio.DepartamentoId);
            ViewBag.EstadoMetodoEnvioId = new SelectList(db.EstadoMetodoEnvio, "Id", "Nombre", metodoEnvio.EstadoMetodoEnvioId);
            ViewBag.TipoMetodoOpcionId = new SelectList(db.TipoMetodoOpcion, "Id", "Nombre", metodoEnvio.TipoMetodoOpcionId);
            return View(metodoEnvio);
        }

        // POST: Reclamaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoMetodoOpcionId,DepartamentoId,FechaInicio,HoraInicio,EstadoMetodoEnvioId,ClienteId")] MetodoEnvio metodoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodoEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nombre", metodoEnvio.ClienteId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentos, "Id", "Nombre", metodoEnvio.DepartamentoId);
            ViewBag.EstadoMetodoEnvioId = new SelectList(db.EstadoMetodoEnvio, "Id", "Nombre", metodoEnvio.EstadoMetodoEnvioId);
            ViewBag.TipoMetodoOpcionId = new SelectList(db.TipoMetodoOpcion, "Id", "Nombre", metodoEnvio.TipoMetodoOpcionId);
            return View(metodoEnvio);
        }

        // GET: Reclamaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoEnvio metodoEnvio = db.MetodoEnvio.Find(id);
            if (metodoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(metodoEnvio);
        }

        // POST: Reclamaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodoEnvio metodoEnvio = db.MetodoEnvio.Find(id);
            db.MetodoEnvio.Remove(metodoEnvio);
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
