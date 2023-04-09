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

        public IActionResult Excluir(Guid id)
        {
            //Faz a exclusão
            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid id)
        {
            //Carrega o objeto a partir do ID passado
            //Carrega uma View com os dados do objeto a serem alterados
            var produto = new ProdutoModel()
            {
                Id = id,
                CategoriaId = id,
                Descricao = "Produto Teste",
                Preco = 10,
                QuantidadeEstoque = 10,
                UnidadeMedida = "UN"
            };

            ViewBag.produto = produto;
            ViewBag.categorias = CategoriaProdutoFactory.GeradorMoqCategoriaProdutos(5);
            return View();
        }
    }
}
