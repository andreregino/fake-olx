using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace TarefaWeb.Models
{
    public class ProdutoModel : Model
    {
        public List<Produto> Read()
        {
            List<Produto> lista = new List<Produto>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * 
                                FROM Produto";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Produto p = new Produto
                {
                    ProdutoId = (int)reader["ProdutoId"],
                    UsuarioId = (int)reader["UsuarioId"],
                    Nome = (string)reader["Nome"],
                    Preco = (Decimal)reader["Preco"],
                    Vendido = (Boolean)reader["Vendido"],
                };

                lista.Add(p);
            }

            return lista;
        }

        public void Create(Produto p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Produto VALUES (@usuarioid, @nome, @preco, @vendido)";
            
            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@preco", p.Preco);
            cmd.Parameters.AddWithValue("@vendido", p.Vendido);
            cmd.Parameters.AddWithValue("@usuarioid", p.UsuarioId);

            cmd.ExecuteNonQuery();
        }

        public void Update(Produto u)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Produto SET Nome = @nome, Preco = @preco, Vendido = @vendido  
                                    WHERE ProdutoId = @id";

            cmd.Parameters.AddWithValue("@nome", u.Nome);
            cmd.Parameters.AddWithValue("@preco", u.Preco);
            cmd.Parameters.AddWithValue("@vendido", u.Vendido);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Produto WHERE ProdutoId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
        


       

        public Produto View(int id)
        {
            Produto p = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Produto
                                WHERE ProdutoId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                p = new Produto
                {
                    ProdutoId = (int)reader["ProdutoId"],
                    UsuarioId = (int)reader["UsuarioId"],
                    Nome = (string)reader["Nome"],
                    Preco = (Decimal)reader["Preco"],
                    Vendido = (bool)reader["Vendido"],
                };
            }

            return p;
        }

        public decimal Buy(Produto p, string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Produto SET Vendido = 1  
                                    WHERE ProdutoId = @id";

            cmd.Parameters.AddWithValue("@id", p.ProdutoId);
            

            cmd.ExecuteNonQuery();

            cmd.CommandText = @"UPDATE Usuario SET Receita = @receita
                                    WHERE Email = @email";

            cmd.Parameters.AddWithValue("@receita", p.Preco);
            cmd.Parameters.AddWithValue("@email", usuario);

            cmd.ExecuteNonQuery();
            return p.Preco;
        }
    }
}