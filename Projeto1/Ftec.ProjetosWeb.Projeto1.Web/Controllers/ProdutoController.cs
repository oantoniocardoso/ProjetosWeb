using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.Projeto1.Web.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View("Inserir");
        }

        public IActionResult Inserir()
        {
            return View();
        }
    }
}
