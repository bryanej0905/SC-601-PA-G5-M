using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SC_601_PA_G5_M.Models.Contabilidad;
using SC_601_PA_G5_M.Models.Empleados;
using SC_601_PA_G5_M.Models.Taller;

namespace SC_601_PA_G5_M.Models
{
    public class PAContext : DbContext
    {
        public PAContext() : base("name=PA05")
        { }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CitaTaller> CitaTaller { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
    }
}