using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IGenerico<T> where T : class
    {
        bool Adicionar(T Objeto);
        Task Editar(T Objeto);
        Task Excluir(Guid Id);
        Task<T> BuscarPorId(Guid Id);
        Task<List<T>> Listar(string busca = null);
    }
}
