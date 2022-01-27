using Dominio.Interfaces;
using Dominio.Servicos;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class RepositorioContato : IRepositorioContato
    {
        private readonly Contexto _DbContexto;

        public RepositorioContato(Contexto dbContext)
        {
            _DbContexto = dbContext;
        }

        public bool Adicionar(Contato contato)
        {
            contato.Idade = DataNascimento.Idade(contato);
            if (contato.Idade < 18 || contato.Nome == "" || contato.Sexo == "")
            {
                return false;
            }
            try
            {
                _DbContexto.Set<Contato>().Add(contato);
                _DbContexto.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task Editar(Contato contato)
        {
            _DbContexto.Set<Contato>().Update(contato);
            await _DbContexto.SaveChangesAsync();
        }

        public async Task<Contato> BuscarPorId(Guid id)
        {
            return await _DbContexto.Set<Contato>().FindAsync(id);
        }

        public async Task Excluir(Guid id)
        {
            var contato = await _DbContexto.Set<Contato>().FindAsync(id);
            _DbContexto.Set<Contato>().Remove(contato);
            await _DbContexto.SaveChangesAsync();
        }

        public async Task<List<Contato>> Listar(string busca = null)
        {
            return await _DbContexto.Set<Contato>().AsNoTracking().ToListAsync();
        }
    }
}
