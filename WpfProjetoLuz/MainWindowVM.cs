using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProjetoLuz
{
    public class MainWindowVM
    {
        public ObservableCollection<Usuario> listaUsuarios { get; set; }

        public ICommand Inserir { get; private set; }

        public ICommand Remover { get; private set; }

        public ICommand Atualizar { get; private set; }

        public ICommand Listar { get; private set; }

        public Usuario UsuarioSelecionado { get; set; }

        public MainWindowVM()
        {
            listaUsuarios = new ObservableCollection<Usuario>() { };

            IniciaComandos();
        }

        public void IniciaComandos()
        {

            Inserir = new RelayCommand( (object _) => {

                Usuario userCadastro = new Usuario();
                CadastroUsuario tela = new CadastroUsuario();
                tela.DataContext = userCadastro;
                bool? verifica = tela.ShowDialog();
                if (verifica.HasValue && verifica.Value)
                {
                    listaUsuarios.Add(userCadastro);
                }
                
            });

            Remover = new RelayCommand((object _) =>
            {  
                listaUsuarios.Remove(UsuarioSelecionado);
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
                }
                
            });


        }

    }
}
