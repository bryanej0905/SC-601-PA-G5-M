using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SC_601_PA_G5_M.Startup))]
namespace SC_601_PA_G5_M
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
