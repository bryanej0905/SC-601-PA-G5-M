using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC_601_PA_G5_M.Models.Usuarios
{
    public class Usuarios
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
    }
}