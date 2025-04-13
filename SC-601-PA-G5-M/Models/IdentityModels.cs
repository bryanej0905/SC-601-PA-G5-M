using Microsoft.AspNet.Identity.EntityFramework;
using SC_601_PA_G5_M.Models.Contabilidad;
using SC_601_PA_G5_M.Models.Taller;
using System.Data.Entity;

namespace SC_601_PA_G5_M.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PA05", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // 👇 Aquí agregás tus modelos personalizados, como CitaTaller
        public DbSet<CitaTaller> CitaTaller { get; set; }

        public System.Data.Entity.DbSet<SC_601_PA_G5_M.Models.Ventas.Producto> Productoes { get; set; }

        public DbSet<TransaccionContable> TransaccionesContables { get; set; }

        // ❌ NO agregues manualmente DbSet<IdentityUserLogin> ni DbSet<IdentityUserRole>
    }
}
