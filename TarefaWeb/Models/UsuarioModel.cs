using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace TarefaWeb.Models
{
    public class Model : IDisposable
    {
        protected SqlConnection conn;

        public Model()
        {
            string strConn = @"Data Source=localhost;
                                Initial Catalog=BDVendaDireta;
                                Integrated Security=true";
            
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
    public class UsuarioModel : Model
    {
        public List<Usuario> Read()
        {
            List<Usuario> lista = new List<Usuario>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * 
                                FROM Usuario";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuario u = new Usuario
                {
                    UsuarioId = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Senha = reader.GetString(3),
                    Receita = reader.GetDecimal(4)
                };

                lista.Add(u);
            }

            return lista;
        }

        public void Create(Usuario u)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Usuario VALUES (@nome, @email, @senha, @receita)";

            cmd.Parameters.AddWithValue("@nome", u.Nome);
            cmd.Parameters.AddWithValue("@email", u.Email);
            cmd.Parameters.AddWithValue("@senha", u.Senha);
            cmd.Parameters.AddWithValue("@receita", u.Receita);

            cmd.ExecuteNonQuery();
        }

        public void Update(Usuario u)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Usuario SET Nome = @nome, Email = @email, Senha = @senha, Receita = @receita 
                                    WHERE UsuarioId = @id";

            cmd.Parameters.AddWithValue("@nome", u.Nome);
            cmd.Parameters.AddWithValue("@email", u.Email);
            cmd.Parameters.AddWithValue("@senha", u.Senha);
            cmd.Parameters.AddWithValue("@receita", u.Receita);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Usuario WHERE UsuarioId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Usuario Read(int id)
        {
            Usuario u = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Usuario
                                WHERE UsuarioId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u = new Usuario
                {
                    UsuarioId = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Senha = reader.GetString(3),
                    Receita = reader.GetDecimal(4)
                };
            }

            return u;
        }

        public Usuario Login(string email, string senha)
        {
            Usuario u = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Usuario
                                WHERE Email = @email AND Senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u = new Usuario
                {
                    UsuarioId = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Senha = reader.GetString(3),
                    Receita = reader.GetDecimal(4)
                };
            }

            return u;
        }

    }
}
