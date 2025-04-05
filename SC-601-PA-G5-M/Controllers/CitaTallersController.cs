using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SC_601_PA_G5_M.Models;
using SC_601_PA_G5_M.Models.Taller;

namespace SC_601_PA_G5_M.Controllers
{
    public class CitaTallersController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CitaTallers
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            var citaTaller = db.CitaTaller
                .Include(c => c.Usuario)
                .Where(c => c.UsuarioId == userId)
                .ToList();

            return View(citaTaller);


        }

        // GET: CitaTallers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitaTaller citaTaller = db.CitaTaller.Find(id);
            if (citaTaller == null)
            {
                return HttpNotFound();
            }
            return View(citaTaller);
        }

        // GET: CitaTallers/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Users, "Id", "UserName"); 
            return View();
        }


        // POST: CitaTallers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,FechaCita,DescripcionServicio,EstadoCita")] CitaTaller citaTaller)
        {
            if (ModelState.IsValid)
            {
                
                citaTaller.UsuarioId = User.Identity.GetUserId();

                db.CitaTaller.Add(citaTaller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Si estás usando ViewBag para algo más
            return View(citaTaller);
        }


        // GET: CitaTallers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitaTaller citaTaller = db.CitaTaller.Find(id);
            if (citaTaller == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Users, "Id", "UserName", citaTaller.UsuarioId);

            return View(citaTaller);
        }

        // POST: CitaTallers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,UsuarioId,FechaCita,DescripcionServicio,EstadoCita")] CitaTaller citaTaller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citaTaller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Users, "Id", "UserName", citaTaller.UsuarioId);

            return View(citaTaller);
        }

        // GET: CitaTallers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitaTaller citaTaller = db.CitaTaller.Find(id);
            if (citaTaller == null)
            {
                return HttpNotFound();
            }
            return View(citaTaller);
        }

        // POST: CitaTallers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CitaTaller citaTaller = db.CitaTaller.Find(id);
            db.CitaTaller.Remove(citaTaller);
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
