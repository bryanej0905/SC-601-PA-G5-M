using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using SC_601_PA_G5_M.Models;
using System.Web.Mvc;
using System;
using System.Web;

[assembly: OwinStartupAttribute(typeof(SC_601_PA_G5_M.Startup))]
namespace SC_601_PA_G5_M
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            IdentityInitializer.InicializarRolesYUsuario(app);
        }
    }
}
