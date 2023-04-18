using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Ftec.ProjetosWeb.Projeto1.Web.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo descrição deve ser informado")]
        [StringLength(40,ErrorMessage ="A descrição não pode ter mais do que 40 caracteres")]
        public string Descricao { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
        public Guid CategoriaId { get; set; }

        //private string descricao;

       /* public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }*/

        /*public string getDescricao()
        {
            return descricao;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }*/

    }
}
