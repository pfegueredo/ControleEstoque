using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ControleEstoque.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var ret = false;

            using (var conexao = new SqlConnection())
            {
                //@"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True");
                //@"Data Source=localhost; Initial Catalog=ControleEstoque; User Id=admin;Password=''"
                conexao.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Database=ControleEstoque;Integrated Security=True";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from usuario where login='{0}' and senha='{1}'", login, senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}