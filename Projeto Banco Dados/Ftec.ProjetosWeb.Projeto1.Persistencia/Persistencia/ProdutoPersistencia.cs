using Ftec.ProjetosWeb.Projeto1.Dominio.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.Projeto1.Persistencia.Persistencia
{
    public class ProdutoPersistencia
    {
        public ProdutoPersistencia() { }

        public Guid Inserir(Produto produto)
        {
            
            using (var con = new Npgsql.NpgsqlConnection("Server = sdb; Port = 5432; Database = teste_ftec; User Id = postgres; Password = 217799;"))
            {
                con.Open();
                using (var comando = new NpgsqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "INSERT INTO public.produto (id, categoriaid, descricao, quantidadeestoque, preco, unidademedida) VALUES(@id, @categoriaid, @descricao, @quantidadeestoque, @preco, @unidademedida);";
                    comando.Parameters.AddWithValue("id",produto.Id);
                    comando.Parameters.AddWithValue("categoriaid", produto.CategoriaId);
                    comando.Parameters.AddWithValue("descricao", produto.Descricao);
                    comando.Parameters.AddWithValue("quantidadeestoque", produto.QuantidadeEstoque);
                    comando.Parameters.AddWithValue("preco", produto.Preco);
                    comando.Parameters.AddWithValue("unidademedida", produto.UnidadeMedida);

                    comando.ExecuteNonQuery();

                }
            }
            return produto.Id;
        }
    }
}
