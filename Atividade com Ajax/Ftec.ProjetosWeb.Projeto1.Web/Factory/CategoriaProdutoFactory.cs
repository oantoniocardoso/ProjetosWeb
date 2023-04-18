using Ftec.ProjetosWeb.Projeto1.Web.Models;

namespace Ftec.ProjetosWeb.Projeto1.Web.Factory
{
    public class CategoriaProdutoFactory
    {
        public static List<CategoriaProdutoModel> GeradorMoqCategoriaProdutos(int numeroObjetos)
        {
            List<CategoriaProdutoModel> categorias = new List<CategoriaProdutoModel>();
            for (int i = 0; i < numeroObjetos; i++)
            {
                categorias.Add(new CategoriaProdutoModel()
                {
                    Descricao = string.Format("Categoria {0}", (i + 1)),
                    Id = Guid.NewGuid(),
                });
            }
            return categorias;
        }
    }
}
