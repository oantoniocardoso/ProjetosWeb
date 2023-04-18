using Ftec.ProjetosWeb.Projeto1.Dominio.Entidades;
using Ftec.ProjetosWeb.Projeto1.Persistencia.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.Projeto1.Aplicacao.Aplicacao
{
    public class ProdutoAplicacao
    {
        private ProdutoPersistencia produtoPersistencia;
        public ProdutoAplicacao() {
            produtoPersistencia = new ProdutoPersistencia();
        }

        public Guid Inserir(Produto produto)
        {
            produto.Id= Guid.NewGuid();
            //Executa a validacao das regras de negocio
            if (string.IsNullOrEmpty(produto.Descricao))
            {
                throw new ApplicationException("A descrição deve ser informada");
            }

            return produtoPersistencia.Inserir(produto);
        }
    }
}
