using Ftec.ProjetosWeb.Projeto1.Web.Factory;
using Ftec.ProjetosWeb.Projeto1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.Projeto1.Web.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var produtos = ProdutoFactory.GeradorMoqProdutos(5);
            ViewBag.produtos = produtos;
            return View();
        }

        public IActionResult Inserir()
        {
            var categias = CategoriaProdutoFactory.GeradorMoqCategoriaProdutos(5);
            ViewBag.categorias = categias;
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(ProdutoModel produto)
        {
            //Faz a gravacao
            return RedirectToAction("Index");
        }
    }
}
