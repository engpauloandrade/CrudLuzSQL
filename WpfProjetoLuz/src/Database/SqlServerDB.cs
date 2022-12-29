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
                    

                    SqlCommand comm = new SqlCommand("UPDATE TB_CADASTRO SET Nome='" + user.Name + 
                                                                "',Email='" + user.Email + "'WHERE Id=" + user.Id + "", _Conn);

                    comm.ExecuteNonQuery();
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
                    SqlCommand _cmd = new SqlCommand("DELETE FROM TB_CADASTRO where Id=" + user.Id + "", _Conn);
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

                    cmd = new SqlCommand("SELECT * FROM TB_CADASTRO", _Conn);
                    ler = cmd.ExecuteReader();
                    while (ler.Read())
                    {
                        Usuario usuario = new Usuario()
                        {
                            Id = ler.GetInt32(0),
                            Name = ler.GetString(1),
                            Email = ler.GetString(2)

                        };

                        listar.Add(usuario);
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

                    string _Inserir = $@"insert into TB_CADASTRO
                                         (Nome,Email,Password)
                                         Values('{user.Name}', '{user.Email}' , '{user.Password}')";

                    SqlCommand _cmd = new SqlCommand(_Inserir, _Conn);

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
