using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Servicos;
using Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class ContatoController : Controller
    {
        IAplicacaoContato _aplicacaoContato;

        public ContatoController(IAplicacaoContato aplicacaoContato)
        {
            _aplicacaoContato = aplicacaoContato;
        }

        public async Task<IActionResult> Index(string busca = null)
        {
            return View(await _aplicacaoContato.Listar(busca));
        }

        public IActionResult Criacao()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criacao(Contato contato)
        {            
            if (!ModelState.IsValid)
            {
                return View(contato);
            }
            bool validacao = _aplicacaoContato.Adicionar(contato);
            if (!validacao)
            {
                return RedirectToAction("Criacao", "Contato", contato.Id);
            }            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var contato = await _aplicacaoContato.BuscarPorId(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editado(Guid id, Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _aplicacaoContato.Editar(contato);
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public async Task<IActionResult> Deletar(Guid id)
        {
            var contato = await _aplicacaoContato.BuscarPorId(id);               
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletando(Guid id)
        {
            await _aplicacaoContato.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            Contato contato = await _aplicacaoContato.BuscarPorId(id);
            return contato == null ? NotFound() : View(contato);
        }

    }
}
