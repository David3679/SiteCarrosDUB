using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.ViewComponentes
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (sessaoUsuario == null) return null;

            UsuariosModel usuario = JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
