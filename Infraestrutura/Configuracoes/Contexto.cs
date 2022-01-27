using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {            
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
