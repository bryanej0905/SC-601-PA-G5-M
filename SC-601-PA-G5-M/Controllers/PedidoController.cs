sing System.Linq;
using System.Web.Mvc;
using SC_601_PA_G5_M.Models;

namespace SC_601_PA_G5_M.Controllers
{
    public class PedidoController : Controller
    {
        private static List<Pedido> pedidos = new List<Pedido>();
        private static int nextId = 1;

        // GET: Pedido
        public ActionResult Index()
        {
            return View(pedidos);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Id = nextId++;
                pedidos.Add(pedido);
                return RedirectToAction("Index");
            }

            return View(pedido);
        }
    }
}