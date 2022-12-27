using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjetoLuz.src.Database
{
    internal interface IDatabase
    {
        List<Usuario> Listar();
        void Inserir(Usuario user);
        void Deletar(Usuario user);
        void Atualizar(Usuario user);

    }
}
