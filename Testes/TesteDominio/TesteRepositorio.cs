using Aplicacao.Aplicacoes;
using Dominio.Interfaces;
using Dominio.Repositorio;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Testes.Base;
using Testes.TesteContato;
using Xunit;

namespace Testes.TesteDominio
{
    public class TesteRepositorio : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public TesteRepositorio(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }
        //AAA
        [Fact]
        public void RepositorioContato_Adicionar_RetornaBool()
        {            
            using (var context = _serviceProvider.GetService<Contexto>())
            {
                ////Arrange
                var repositorioContato = new RepositorioContato(context);
                var contato = GerarContato.GerarContatoValido();
                ////Act
                var resultado = repositorioContato.Adicionar(contato);
                //Assert
                Assert.True(resultado);
            }
        }
        //AAA
        [Fact]
        public void RepositorioContato_Adicionar_RetornaFalse1()
        {            
            using (var context = _serviceProvider.GetService<Contexto>())
            {
                ////Arrange
                var repositorioContato = new RepositorioContato(context);
                var contato = GerarContato.GerarContatoInvalidoNome();
                ////Act
                var resultado = repositorioContato.Adicionar(contato);
                //Assert
                Assert.False(resultado);
            }
        }
        //AAA
        [Fact]
        public void RepositorioContato_Adicionar_RetornaFalse2()
        {
            using (var context = _serviceProvider.GetService<Contexto>())
            {
                ////Arrange
                var repositorioContato = new RepositorioContato(context);
                var contato = GerarContato.GerarContatoInvalidoDNascimento();
                ////Act
                var resultado = repositorioContato.Adicionar(contato);
                //Assert
                Assert.False(resultado);
            }
        }
        //AAA
        [Fact]
        public void RepositorioContato_Adicionar_RetornaFalse3()
        {
            using (var context = _serviceProvider.GetService<Contexto>())
            {
                ////Arrange
                var repositorioContato = new RepositorioContato(context);
                var contato = GerarContato.GerarContatoInvalidoIdade();
                ////Act
                var resultado = repositorioContato.Adicionar(contato);
                //Assert
                Assert.False(resultado);
            }
        }
        //AAA
        [Fact]
        public void RepositorioContato_Adicionar_RetornaFalse4()
        {
            using (var context = _serviceProvider.GetService<Contexto>())
            {
                ////Arrange
                var repositorioContato = new RepositorioContato(context);
                var contato = GerarContato.GerarContatoInvalidoGenero();
                ////Act
                var resultado = repositorioContato.Adicionar(contato);
                //Assert
                Assert.False(resultado);
            }
        }
    }
}
