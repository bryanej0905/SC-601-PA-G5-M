using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using SC_601_PA_G5_M.Models;

public class BaseController : Controller
{
    protected ApplicationDbContext db = new ApplicationDbContext();

    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = User.Identity.GetUserId();
            var nombre = db.Users.Where(u => u.Id == userId).Select(u => u.Nombre).FirstOrDefault();
            ViewBag.NombreUsuario = nombre;
        }

        base.OnActionExecuting(filterContext);
    }
}
