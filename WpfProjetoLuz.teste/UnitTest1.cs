global using Xunit;
using WpfProjetoLuz.src.Database;
using System.Collections.ObjectModel;
using Moq;
using Autofac.Extras.Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using IDatabase = WpfProjetoLuz.src.Database.IDatabase;

namespace WpfProjetoLuz.teste
{
    public class UnitTest1
    {
        

        [Fact]
        public void Listando_Um_Usuario()
        {
            // Organizar
            var mock = new Mock<IDatabase>();
            mock.Setup(x => x.Listar())
                .Returns(new List<Usuario>
                {
                    new Usuario { Id = 1, Name = "Paulo", Email = "paulo@gmail.com" },
                    new Usuario { Id = 2, Name = "Natalia", Email = "teste@example.com" }
                });

            // Agir
            var result = mock.Object.Listar();

            // Declarar
            Assert.IsType<List<Usuario>>(result);
            Assert.Equal(2, result.Count);

        }

        [Fact]
        public void Deletando_Um_Usuario()
        {
            // Organizar
            var mock = new Mock<IDatabase>();
            mock.Setup(x => x.Deletar(It.IsAny<Usuario>()));

            // Agir
            mock.Object.Deletar(new Usuario { Id = 1 });

            // Declarar
            mock.Verify(x => x.Deletar(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        public void Inserindo_Um_Usuario()
        {
            // Organizar
            var mock = new Mock<IDatabase>();
            mock.Setup(x => x.Inserir(It.IsAny<Usuario>()));

            // Agir
            mock.Object.Inserir(new Usuario { Id = 1, Name = "Paulo", Email = "paulo@gmail.com", Password = "123456" });

            // Declarar
            mock.Verify(x => x.Inserir(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]

        public void Atualizando_Um_Usuario()
        {
            // Organizar
            var mock = new Mock<IDatabase>();
            mock.Setup(x => x.Atualizar(It.IsAny<Usuario>()));

            // Agir
            mock.Object.Atualizar(new Usuario { Id = 1, Name = "Paulo", Email = "teste@gmail.com" });

            // Declarar
            mock.Verify(x => x.Atualizar(It.IsAny<Usuario>()), Times.Once());
        }

    }
}