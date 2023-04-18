using Ftec.ProjetosWeb.Projeto1.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.Projeto1.Web.Factory;
using Ftec.ProjetosWeb.Projeto1.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ftec.ProjetosWeb.Projeto1.Web.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var produtos = ProdutoFactory.GeradorMoqProdutos(5);
            //ViewBag.produtos = produtos;

            HttpContext.Session.SetString("usuario", "Juliano");
            return View(produtos);
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
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao(); 


            decimal custo = 10;

           if (ModelState.IsValid)
            {
                
                if (produto.Preco < custo)
                {
                    ModelState.AddModelError("errocusto", "O preco não pode ser menor que o custo");
                    var categias = CategoriaProdutoFactory.GeradorMoqCategoriaProdutos(5);
                    ViewBag.categorias = categias;
                    return View("Inserir");
                }

                produtoAplicacao.Inserir(new Dominio.Entidades.Produto()
                {
                    Id= produto.Id,
                    CategoriaId = produto.CategoriaId,
                    Descricao= produto.Descricao,
                    QuantidadeEstoque = produto.QuantidadeEstoque,
                    Preco= produto.Preco,
                    UnidadeMedida = produto.UnidadeMedida
                });

                //Faz a gravacao
                return RedirectToAction("Index");
            }
            else
            {
                var categias = CategoriaProdutoFactory.GeradorMoqCategoriaProdutos(5);
                ViewBag.categorias = categias;
                return View("Inserir");
            }
            
        }

        public IActionResult Excluir(Guid id)
        {
            //Faz a exclusão
            return RedirectToAction("Index");
        }

        public IActionResult DecrementarEstoque(Guid id)
        {
            var produtoRetorno = new ProdutoModel()
            {
                Id = id,
                QuantidadeEstoque = 99
            };

            return Json(produtoRetorno);
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
