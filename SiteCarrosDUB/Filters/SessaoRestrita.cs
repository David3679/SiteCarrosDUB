using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Filters
{
    public class SessaoRestrita : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado"); 

            if(string.IsNullOrEmpty(sessaoUsuario) ) 
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UsuariosModel usuarios = JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);

                if (usuarios == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if(usuarios.Perfil != Enuns.PerfilEnum.Admin) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "SessaoRestrita" }, { "action", "Index" } });
                }
            }

        }



    }
}
