using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SC_601_PA_G5_M.Models;
using SC_601_PA_G5_M.Models.Usuarios;

namespace SC_601_PA_G5_M.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
           
            var model = db.Users.ToList().Select(u => new Usuarios
            {
                Id = u.Id,
                Usuario = u.UserName,
                Nombre = u.Nombre,
                Email = u.Email,
                Telefono = u.PhoneNumber,
                Rol = userManager.GetRoles(u.Id).FirstOrDefault() ?? "Sin Rol"
            }).ToList();

            return View(model);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var roles = db.Roles.Select(r => r.Name).ToList();
            ViewBag.Roles = new SelectList(roles);
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var nuevoUsuario = new ApplicationUser
                {
                    UserName = model.Usuario,
                    Email = model.Email,
                    Nombre = model.Nombre,
                    PhoneNumber = model.Telefono,
                    EmailConfirmed = true // opcional
                };

                var resultado = userManager.Create(nuevoUsuario, "Default123!"); // Cambiá la contraseña si querés

                if (resultado.Succeeded)
                {
                    userManager.AddToRole(nuevoUsuario.Id, model.Rol);
                    return RedirectToAction("Index");
                }
                else
                {
                    // Mostrar errores en la vista
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            var roles = db.Roles.Select(r => r.Name).ToList();
            ViewBag.Roles = new SelectList(roles, model.Rol);
            return View(model);
        }


        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = db.Users.Find(id);
            if (user == null) return HttpNotFound();

            var model = new Usuarios
            {
                Id = user.Id,
                Usuario = user.UserName,
                Nombre = user.Nombre,
                Email = user.Email,
                Telefono = user.PhoneNumber,
                Rol = userManager.GetRoles(user.Id).FirstOrDefault() ?? "Sin Rol"
            };

            return View(model);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = db.Users.Find(id);
            if (user == null) return HttpNotFound();

            var roles = db.Roles.Select(r => r.Name).ToList();
            ViewBag.Roles = new SelectList(roles, userManager.GetRoles(user.Id).FirstOrDefault());

            return View(new Usuarios
            {
                Id = user.Id,
                Usuario = user.UserName,
                Nombre = user.Nombre,
                Email = user.Email,
                Telefono = user.PhoneNumber,
                Rol = userManager.GetRoles(user.Id).FirstOrDefault()
            });
        }

        // POST: Usuarios/Edit
        [HttpPost]
        public ActionResult Edit(Usuarios model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = db.Users.Find(model.Id);
            if (user == null) return HttpNotFound();

            // Actualizar propiedades
            user.UserName = model.Usuario;
            user.Nombre = model.Nombre;
            user.Email = model.Email;
            user.PhoneNumber = model.Telefono;
            db.SaveChanges();

            // Cambiar rol
            var currentRoles = userManager.GetRoles(user.Id);
            foreach (var role in currentRoles)
            {
                userManager.RemoveFromRole(user.Id, role);
            }
            userManager.AddToRole(user.Id, model.Rol);

            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = db.Users.Find(id);
            if (user == null) return HttpNotFound();

            var model = new Usuarios
            {
                Id = user.Id,
                Usuario = user.UserName,
                Nombre = user.Nombre,
                Email = user.Email,
                Telefono = user.PhoneNumber,
                Rol = userManager.GetRoles(user.Id).FirstOrDefault() ?? "Sin Rol"
            };

            return View(model);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
