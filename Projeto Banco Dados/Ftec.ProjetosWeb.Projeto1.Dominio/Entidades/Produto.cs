using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.Projeto1.Dominio.Entidades
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
        public Guid CategoriaId { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
            Descricao= string.Empty;
            QuantidadeEstoque = 0;
            Preco = 0;
            UnidadeMedida = string.Empty;
            CategoriaId= Guid.NewGuid();
        }
    }
}
