using Domain.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Repository.Impl
{
    public class ClienteRepository
    {
        string conexao = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

        public void Save(Cliente cliente)
        {
            using(var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                if (cliente.ID == 0)
                    cmd.CommandText = @"INSERT INTO CLIENTE (CPF, NOME, TELEFONE, ENDERECO) 
                                    VALUES (@CPF, @NOME, @TELEFONE, @ENDERECO)";
                else
                {
                    cmd.CommandText = @"UPDATE CLIENTE SET CPF = @CPF, NOME = @NOME,
                                        TELEFONE = @TELEFONE, ENDERECO = @ENDERECO
                                        WHERE ID = @ID";
                    
                    cmd.Parameters.AddWithValue("ID", cliente.ID);
                }
                cmd.Parameters.AddWithValue("CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("NOME", cliente.Nome);
                cmd.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
                cmd.Parameters.AddWithValue("ENDERECO", cliente.Endereco);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally 
                {   
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        public Cliente Get(int codigo)
        {
            using(var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT ID, CPF, NOME, TELEFONE, ENDERECO
                                    FROM CLIENTE WHERE ID = @ID";

                cmd.Parameters.AddWithValue("ID", codigo);

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                Cliente cli = new Cliente();
                while(dr.Read())
                {
                    cli.ID = (int)dr["ID"];
                    cli.CPF = (string)dr["CPF"];
                    cli.Nome = (string)dr["NOME"];
                    cli.Telefone = (string)dr["TELEFONE"];
                    cli.Endereco = (string)dr["ENDERECO"];
                }
                cn.Close();

                return cli;
            }

            return new Cliente();
        }

        public List<Cliente> List(string nome)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CLIENTE";

                if (!string.IsNullOrEmpty(nome))
                {
                    cmd.CommandText += " WHERE NOME LIKE '@NOME'";
                    cmd.Parameters.AddWithValue("NOME", nome);
                }

                SqlDataReader dr = null;
                cn.Open();
                dr = cmd.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();
                while (dr.Read())
                {
                    Cliente cli = new Cliente();

                    cli.ID = (int)dr["ID"];
                    cli.CPF = (string)dr["CPF"];
                    cli.Nome = (string)dr["NOME"];
                    cli.Telefone = (string)dr["TELEFONE"];
                    cli.Endereco = (string)dr["ENDERECO"];

                    lista.Add(cli);
                }
                cn.Close();

                return lista;
            }

            return new List<Cliente>();
        }

        public void Delete(int codigo)
        {
            using (var cn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM CLIENTE WHERE ID = @ID";

                cmd.Parameters.AddWithValue("ID", codigo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
