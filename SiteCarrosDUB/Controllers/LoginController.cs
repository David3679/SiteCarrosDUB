using Microsoft.AspNetCore.Mvc;
using SiteCarrosDUB.Filters;
using SiteCarrosDUB.Helper;
using SiteCarrosDUB.Models;
using SiteCarrosDUB.Repositorios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteCarrosDUB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuariosRepositorio usuariosRepositorio,
                               ISessao sessao,
                               IEmail email)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            
            return View();
        }
        public IActionResult RedefinirSenha()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuarios();
            
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                UsuariosModel usuarios = _usuariosRepositorio.ListarPorLogin(loginModel.Login);
                
                if (usuarios != null)
                {
                    if(usuarios.SenhaValida(loginModel.Senha)) 
                    {
                        _sessao.CriarSessaoUsuario(usuarios);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = "Senha do usuário inválida, por favor tente novamente";
                }

                TempData["MensagemErro"] = "Login e/ou Senha do usuário inválido(s), por favor tente novamente";
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao tentar entrar, mais detalhes do erro:{erro.Message}";
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult LinkRedefinirSenha(RedefinirSenha redefinirSenha) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosModel usuario = _usuariosRepositorio.ListarPorEmailELogin(redefinirSenha.Email, redefinirSenha.Login);
                    if(usuario != null)
                    {
                        string novaSenha = usuario.NovaSenhaHash();
                        string mensagem = $"Sua nova senha é {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Site DUB - Redefinição de Senha", mensagem);
                        if(emailEnviado)
                        {
                            _usuariosRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = "Enviamos uma nova senha para o seu e-mail";
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Não conseguimos enviar o e-mail, por favor tente novamente";
                        }
                        return RedirectToAction("Index", "Login");
                    }
                }
                TempData["MensagemErro"] = "Login e/ou E-mail informados estão incorretos, por favor tente novamente";
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao tentar entrar, mais detalhes do erro:{erro.Message}";
                return View("Index");
            }
        }
    }
}
