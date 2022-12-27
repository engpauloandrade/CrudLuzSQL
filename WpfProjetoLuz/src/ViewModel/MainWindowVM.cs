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

namespace WpfProjetoLuz
{
    public class MainWindowVM
    {
        public ObservableCollection<Usuario> listaUsuarios { get; set; }

        public ICommand Inserir { get; private set; }

        public ICommand Remover { get; private set; }

        public ICommand Atualizar { get; private set; }

        public ICommand Listar { get; private set; }

        private IDatabase conexao { get; set; }

        public Usuario UsuarioSelecionado { get; set; }

        public MainWindowVM()
        {
            conexao = new SqlServerDB();

            listaUsuarios = new ObservableCollection<Usuario>(conexao.Listar()) { };


            IniciaComandos();

            

        }

        

        public void IniciaComandos()
        {
                
            Inserir = new RelayCommand((object _) => {

                Usuario userCadastro = new Usuario();
                CadastroUsuario tela = new CadastroUsuario();
                tela.DataContext = userCadastro;
                bool? verifica = tela.ShowDialog();

                if (verifica.HasValue && verifica.Value)
                {
                    conexao.Inserir(userCadastro);
                    
                }
                AtualizarLista();
            });


            Remover = new RelayCommand((object _) =>
            {
                Usuario usuario = UsuarioSelecionado;
                conexao.Deletar(usuario);
                AtualizarLista();


            });


            Atualizar = new RelayCommand((object _) =>
            {
                Usuario usuario = UsuarioSelecionado.Clone();

                CadastroUsuario telaAtualizar = new CadastroUsuario();
                telaAtualizar.DataContext = usuario;
                bool? verifica = telaAtualizar.ShowDialog();

                if(verifica.HasValue && verifica.Value)
                {
                    UsuarioSelecionado.Name = usuario.Name;
                    UsuarioSelecionado.Email = usuario.Email;
                    UsuarioSelecionado.Password = usuario.Password;

                    conexao.Atualizar(UsuarioSelecionado);
                }
                AtualizarLista();
            });
        }

        private void AtualizarLista()
        {
            listaUsuarios.Clear();

            ObservableCollection<Usuario> list = null;

            try
            {
                list = new ObservableCollection<Usuario>(conexao.Listar());
                for (int i = 0; i < list.Count; i++)
                    listaUsuarios.Add(list[i]);
            }
            catch (Exception)
            {
                MessageBox.Show("Error establishing database connection.\nPlease contact our support team");
                Application.Current.Shutdown();
            }
        }

    }
}
