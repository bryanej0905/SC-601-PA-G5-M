using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SC_601_PA_G5_M.Models;
using SC_601_PA_G5_M.Models.Contabilidad;

namespace SC_601_PA_G5_M.Controllers
{
    [Authorize(Roles = "Admin")] // Solo administradores pueden acceder
    public class TransaccionesContablesController : BaseController
    {
        // GET: TransaccionesContables
        public ActionResult Index()
        {
            var transacciones = db.TransaccionesContables
                .Include(t => t.CitaTaller)
                .Include(t => t.Producto)
                .OrderByDescending(t => t.FechaTransaccion)
                .ToList();
            return View(transacciones);
        }

        // GET: TransaccionesContables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransaccionContable transaccion = db.TransaccionesContables
                .Include(t => t.CitaTaller)
                .Include(t => t.Producto)
                .FirstOrDefault(t => t.IdTransaccion == id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: TransaccionesContables/Create
        public ActionResult Create()
        {
            PopulateDropdownLists();
            return View();
        }

        // POST: TransaccionesContables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTransaccion,FechaTransaccion,TipoTransaccion,Monto,Descripcion,CitaTallerId,ProductoId")] TransaccionContable transaccion)
        {
            if (ModelState.IsValid)
            {
                db.TransaccionesContables.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDropdownLists(transaccion);
            return View(transaccion);
        }

        // GET: TransaccionesContables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransaccionContable transaccion = db.TransaccionesContables.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            PopulateDropdownLists(transaccion);
            return View(transaccion);
        }

        // POST: TransaccionesContables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTransaccion,FechaTransaccion,TipoTransaccion,Monto,Descripcion,CitaTallerId,ProductoId")] TransaccionContable transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropdownLists(transaccion);
            return View(transaccion);
        }

        // GET: TransaccionesContables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransaccionContable transaccion = db.TransaccionesContables
                .Include(t => t.CitaTaller)
                .Include(t => t.Producto)
                .FirstOrDefault(t => t.IdTransaccion == id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: TransaccionesContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransaccionContable transaccion = db.TransaccionesContables.Find(id);
            db.TransaccionesContables.Remove(transaccion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDropdownLists(TransaccionContable transaccion = null)
        {
            // Obtener todas las citas activas
            ViewBag.CitaTallerId = new SelectList(db.CitaTaller
                .OrderByDescending(c => c.FechaCita),
                "IdCita",
                "DescripcionServicio",
                transaccion?.CitaTallerId);

            // Obtener todos los productos
            ViewBag.ProductoId = new SelectList(db.Productoes
                .OrderBy(p => p.NombreProducto),
                "IdProducto",
                "NombreProducto",
                transaccion?.ProductoId);
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
