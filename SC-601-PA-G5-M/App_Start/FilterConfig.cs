using System.Web;
using System.Web.Mvc;

namespace SC_601_PA_G5_M
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
