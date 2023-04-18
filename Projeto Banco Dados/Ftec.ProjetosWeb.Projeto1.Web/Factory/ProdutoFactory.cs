using Ftec.ProjetosWeb.Projeto1.Web.Models;

namespace Ftec.ProjetosWeb.Projeto1.Web.Factory
{
    public class ProdutoFactory
    {
        public static List<ProdutoModel> GeradorMoqProdutos( int numeroObjetos)
        {
            List<ProdutoModel> produtos= new List<ProdutoModel>();
            for (int i= 0; i < numeroObjetos; i++)
            {
                produtos.Add(new ProdutoModel()
                {
                    Descricao = string.Format("Descricao {0}",(i+1)),
                    Id = Guid.NewGuid(),
                    Preco = 10,
                    QuantidadeEstoque= 10,
                    UnidadeMedida = "UN",
                    CategoriaId = Guid.NewGuid()
                });
            }
            return produtos;
        }
    }
}
