using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
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
