using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Owin;
using SC_601_PA_G5_M.Models;

public static class IdentityInitializer
{
    public static void InicializarRolesYUsuario(IAppBuilder app)
    {
        var context = new ApplicationDbContext();

        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        string[] roles = { "Admin", "Usuario" };

        // Crear roles si no existen
        foreach (var rol in roles)
        {
            if (!roleManager.RoleExists(rol))
            {
                roleManager.Create(new IdentityRole(rol));
            }
        }

        // Crear usuario quemado
        var user = userManager.FindByName("admin@motos.com");
        if (user == null)
        {
            var nuevoUsuario = new ApplicationUser
            {
                UserName = "admin@motos.com",
                Email = "admin@motos.com",
                Nombre = "Administrador"
            };

            var result = userManager.Create(nuevoUsuario, "Admin123!");
            if (result.Succeeded)
            {
                userManager.AddToRole(nuevoUsuario.Id, "Admin");
            }
        }

        context.Dispose();
    }
}
