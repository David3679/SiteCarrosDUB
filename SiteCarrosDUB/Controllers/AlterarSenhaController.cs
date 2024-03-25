using Microsoft.AspNetCore.Mvc;
using SiteCarrosDUB.Filters;
using SiteCarrosDUB.Helper;
using SiteCarrosDUB.Models;
using SiteCarrosDUB.Repositorios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteCarrosDUB.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuariosRepositorio usuariosRepositorio,
                                      ISessao sessao)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {             
                UsuariosModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if(ModelState.IsValid) 
                {                  
                    _usuariosRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                TempData["MensagemErro"] = "Houve um erro ao tentar redefinir a senha, mais detalhes do erro";
                return View("Index", alterarSenhaModel);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao tentar redefinir a senha, mais detalhes do erro:{erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
