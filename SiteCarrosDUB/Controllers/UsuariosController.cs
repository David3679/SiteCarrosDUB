using Microsoft.AspNetCore.Mvc;
using SiteCarrosDUB.Filters;
using SiteCarrosDUB.Models;
using SiteCarrosDUB.Repositorios;

namespace SiteCarrosDUB.Controllers
{
    [SessaoRestrita]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        public UsuariosController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuariosModel> usuarios = _usuariosRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult ApagarUsuarios(int id)
        {
            UsuariosModel usuarios = _usuariosRepositorio.ListarPorId(id);
            return View(usuarios);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuariosRepositorio.Apagar(id);
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
            UsuariosModel usuarios = _usuariosRepositorio.ListarPorId(id);
            return View(usuarios);
        }
        [HttpPost]
        public IActionResult Criar(UsuariosModel usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuariosRepositorio.Adicionar(usuarios);
                    TempData["MensagemSucesso"] = "Contato criado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuarios);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar este contato, detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Editar(UsuariosSemSenhaModel usuariosSemSenhaModel)
        {
            try
            {
                UsuariosModel usuarios = null;
                if (ModelState.IsValid)
                {
                    usuarios = new UsuariosModel()
                    {
                        Id = usuariosSemSenhaModel.Id,
                        Nome = usuariosSemSenhaModel.Nome,
                        Login = usuariosSemSenhaModel.Login,
                        Email = usuariosSemSenhaModel.Email,
                        Perfil = usuariosSemSenhaModel.Perfil
                    };
                    usuarios = _usuariosRepositorio.Atualizar(usuarios);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuariosSemSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao alterar o contato, mais detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
