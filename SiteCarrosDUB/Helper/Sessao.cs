using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SiteCarrosDUB.Models;
using System.Reflection.Metadata.Ecma335;


namespace SiteCarrosDUB.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContextAcessor)
        {
            _httpContext = httpContextAcessor;
        }


        public UsuariosModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuariosModel usuario)
        {

            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);

        }

        public void RemoverSessaoUsuarios()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
