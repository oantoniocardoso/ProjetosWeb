using Ftec.ProjetosWeb.Projeto1.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.Projeto1.Dominio.Entidades;
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
            List<ProdutoModel> produtosModel = new List<ProdutoModel>();
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao();

            var produtos = produtoAplicacao.SelecionarTodos();

            foreach(var prod in produtos)
            {
                produtosModel.Add(new ProdutoModel()
                {
                    CategoriaId = prod.CategoriaId,
                    Descricao = prod.Descricao,
                    Id = prod.Id,
                    Preco = prod.Preco,
                    QuantidadeEstoque = prod.QuantidadeEstoque,
                    UnidadeMedida = prod.UnidadeMedida
                });
            }

            HttpContext.Session.SetString("usuario", "Juliano");
            return View(produtosModel);
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

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
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
                    return View("Editar");
                }

                produtoAplicacao.Alterar(new Dominio.Entidades.Produto()
                {
                    Id = produto.Id,
                    CategoriaId = produto.CategoriaId,
                    Descricao = produto.Descricao,
                    QuantidadeEstoque = produto.QuantidadeEstoque,
                    Preco = produto.Preco,
                    UnidadeMedida = produto.UnidadeMedida
                });

                //Faz a gravacao
                return RedirectToAction("Index");
            }
            else
            {
                var categias = CategoriaProdutoFactory.GeradorMoqCategoriaProdutos(5);
                ViewBag.categorias = categias;
                return View("Editar");
            }

        }

        public IActionResult Excluir(Guid id)
        {
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao();
            //Faz a exclusão
            produtoAplicacao.Excluir(id);
            
            return RedirectToAction("Index");
        }

        public IActionResult DecrementarEstoque(Guid id)
        {
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao();
            var prod = produtoAplicacao.DecrementarEstoque(id);
            
            
            var produtoRetorno = new ProdutoModel()
            {
                Id = prod.Id,
                QuantidadeEstoque = prod.QuantidadeEstoque
            };

            return Json(produtoRetorno);
        }

        public IActionResult Editar(Guid id)
        {
            ProdutoAplicacao produtoAplicacao = new ProdutoAplicacao();

            Produto prod = produtoAplicacao.SelecionarPorId(id);

            //Carrega o objeto a partir do ID passado
            //Carrega uma View com os dados do objeto a serem alterados
            var produto = new ProdutoModel()
            {
                Id = prod.Id,
                CategoriaId = prod.CategoriaId,
                Descricao = prod.Descricao,
                Preco = prod.Preco,
                QuantidadeEstoque = prod.QuantidadeEstoque,
                UnidadeMedida = prod.UnidadeMedida
            };

            ViewBag.produto = produto;
            ViewBag.categorias = CategoriaProdutoFactory.GeradorMoqCategoriaProdutos(5);
            return View();
        }
    }
}
