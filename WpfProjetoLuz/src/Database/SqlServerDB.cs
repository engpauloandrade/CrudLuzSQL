using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfProjetoLuz.src.Database;

namespace WpfProjetoLuz.src.Database
{
    public class SqlServerDB : IDatabase
    {
        public readonly string _strinConexao;
        private SqlDataReader ler;
        private SqlCommand cmd;

        public SqlServerDB()
        {
            //Comentar quando for fazer os testes unitários
            _strinConexao = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        }

        public void Atualizar(Usuario user)
        {
            try
            {

                using (SqlConnection _Conn = new SqlConnection(_strinConexao))
                {
                    // abre a conexao
                    _Conn.Open();
                    
                    SqlCommand _cmd = new SqlCommand("PR_CADASTRO_UPD", _Conn);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.AddWithValue("@Id", user.Id);
                    _cmd.Parameters.AddWithValue("@Nome", user.Name);
                    _cmd.Parameters.AddWithValue("@Email", user.Email);

                    _cmd.ExecuteNonQuery();
                    _Conn.Close();
                    MessageBox.Show("Cadastro atualizado!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        public void Deletar(Usuario user)
        {

            try
            {
                using (SqlConnection _Conn = new SqlConnection(_strinConexao))
                {
                    // abre a conexao
                    _Conn.Open();

                    // inicializa o comando e a conexão
                    SqlCommand _cmd = new SqlCommand("PR_CADASTRO_DEL", _Conn);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.AddWithValue("@Id", user.Id);

                    _cmd.ExecuteNonQuery();
                    _Conn.Close();
                    MessageBox.Show("Registro excluído!");
                }

            }
            catch (Exception ex)
            {
                ex.Source = _strinConexao;
            };
        }

        public List<Usuario> Listar()
        {
            List<Usuario> listar = new List<Usuario>();

            try
            {
                using (SqlConnection _Conn = new SqlConnection(_strinConexao))
                {
                    // abre a conexao
                    _Conn.Open();

                    // inicializa o comando e a conexão
                    SqlCommand _cmd = new SqlCommand("PR_CADASTRO_SEL", _Conn);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                            listar.Add(usuario);
                        }
                    }

                    //fecha a conexao
                    _Conn.Close();      
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            return listar;
        }


        public void Inserir(Usuario user)
        {
            
            try
            {
                
                using (SqlConnection _Conn = new SqlConnection(_strinConexao))
                {
                    // abre a conexao
                    _Conn.Open();

                    SqlCommand _cmd = new SqlCommand("PR_CADASTRO_INS", _Conn);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.AddWithValue("@Nome",  user.Name);
                    _cmd.Parameters.AddWithValue("@Email", user.Email);
                    _cmd.Parameters.AddWithValue("@Password", user.Password);

                    _cmd.ExecuteNonQuery();
                    _Conn.Close();
                    MessageBox.Show("Registro incluído!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

    }
}
