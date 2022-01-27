using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoContato : IAplicacaoContato
    {
        private readonly IRepositorioContato _repositorioContato;

        public AplicacaoContato(IRepositorioContato repositorioContato)
        {
            _repositorioContato = repositorioContato;
        }

        public bool Adicionar(Contato contato)
        {
            return _repositorioContato.Adicionar(contato);
        }

        public async Task Editar(Contato contato)
        {
            await _repositorioContato.Editar(contato);
        }

        public async Task<Contato> BuscarPorId(Guid id)
        {
            return await _repositorioContato.BuscarPorId(id);
        }

        public async Task Excluir(Guid id)
        {
            await _repositorioContato.Excluir(id);
        }

        public Task<List<Contato>> Listar(string busca = null)
        {
            return _repositorioContato.Listar(busca);
        }
    }
}
