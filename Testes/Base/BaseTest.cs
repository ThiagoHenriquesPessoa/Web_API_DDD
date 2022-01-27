using Infraestrutura.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Testes.Base
{
    public abstract class BaseTest
    {
        public BaseTest(){}
    }
    public class DbTest : IDisposable
    {
        // Essa linha de código eu crio o nome do banco de dados com Guid pra nunca ficar repetindo
        private string dataBaseName = $"dbApiTest{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider serviceProvider { get; private set; }
        public DbTest()
        {
            // Aqui em embaixo temos o contexto criado para fazer os testes
            var serviceCollection = new ServiceCollection();
            // Esse é contexto criando para ter conexão com banco de dados
            serviceCollection.AddDbContext<Contexto>(o =>
                o.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={dataBaseName};Trusted_Connection=True;MultipleActiveResultSets=true"),
                ServiceLifetime.Transient
            );
            // Linha de codigo que vai criar o banco de dados
            serviceProvider = serviceCollection.BuildServiceProvider();
            using (var context = serviceProvider.GetService<Contexto>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            // Linha de condigo que vai deletar o bd quando pararmos de usar
            using (var context = serviceProvider.GetService<Contexto>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
