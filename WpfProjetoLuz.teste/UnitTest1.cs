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
        private SqlServerDB alvoDoTeste = new SqlServerDB();

        public Usuario user { get; set; }

        [Theory]
        [InlineData(1, "Teste1", "teste1@gmail.com", "123456")]
        [InlineData(1, "Teste2", "teste2@gmail.com", "123456")]
        [InlineData(1, "Teste3", "teste3@gmail.com", "12345")]
        public void Validar_Um_Usuario(int id, string nome, string email, string password)
        {

            //Organizar
            user = new Usuario()
            {
                Id = id,
                Name = nome,
                Email = email,
                Password = password
            };

            //Agir
            bool? atual = user.Equals(user);

            //Declarar
            Assert.True(atual);

        }

        [Fact]

        public void Listando_Um_Usuario()
        {
            // Organizar
            var mock = new Mock<IDatabase>();
            mock.Setup(x => x.Listar())
                .Returns(new List<Usuario>
                {
                    new Usuario { Id = 1, Name = "Paulo", Email = "paulo@gmail.com" },
                    new Usuario { Id = 2, Name = "Natalia", Email = "teste@examplo.com" }
                });

            // Agir
            var resultado = mock.Object.Listar();

            // Declarar
            Assert.IsType<List<Usuario>>(resultado);
            Assert.Equal(2, resultado.Count);

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
            mock.Verify(x => x.Deletar(It.IsAny<Usuario>()), Times.Exactly(1));
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
            mock.Verify(x => x.Inserir(It.IsAny<Usuario>()), Times.Exactly(1));
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
            mock.Verify(y => y.Atualizar(It.IsAny<Usuario>()), Times.Exactly(1));
        }
    }
}