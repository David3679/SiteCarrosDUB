using Microsoft.AspNetCore.Mvc;
using SiteCarrosDUB.Filters;
using SiteCarrosDUB.Models;
using SiteCarrosDUB.Repositorios;

namespace SiteCarrosDUB.Controllers
{
    [SessaoRestrita]
    public class AcessoriosController : Controller
    {
        private readonly IAcessoriosRepositorio _acessoriosRepositorio;
        public AcessoriosController(IAcessoriosRepositorio acessoriosRepositorio)
        {
            _acessoriosRepositorio = acessoriosRepositorio;
        }
        public IActionResult Index()
        {
            List<AcessoriosModel> acessorios = _acessoriosRepositorio.BuscarTodos();
            return View(acessorios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult ApagarAcessorio(int id)
        {
            AcessoriosModel acessorios = _acessoriosRepositorio.ListarPorId(id);
            return View(acessorios);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _acessoriosRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Houve um erro ao apagar o contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao apagar o contato, mais detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            AcessoriosModel acessorios = _acessoriosRepositorio.ListarPorId(id);
            return View(acessorios);
        }
        [HttpPost]
        public IActionResult Criar(AcessoriosModel acessoriosModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _acessoriosRepositorio.Adicionar(acessoriosModel);
                    TempData["MensagemSucesso"] = "Contato criado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(acessoriosModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar este contato, detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Editar(AcessoriosModel acessoriosModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _acessoriosRepositorio.Atualizar(acessoriosModel);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", acessoriosModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao alterar o contato, mais detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
