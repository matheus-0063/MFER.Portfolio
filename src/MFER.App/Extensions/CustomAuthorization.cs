using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MFER.App.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidateClaimsUser(HttpContext context, string claimName, string claimValue)
        {
            if (context.User.Identity == null) throw new InvalidOperationException("User is not authenticated.");

            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Split(',').Contains(claimValue));
            /*
             * O return, retorna true quando o usuario estiver autenticado e
             * se o claimName for igual o ClaimType, e houver, na sequencia de claimValue (VI, EX, ED, AD)
             * conter no ClaimValue.
             */
        }

        public class RequisitoClaimFilter(Claim claim) : IAuthorizationFilter
        {
            private readonly Claim _claim = claim;

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (context.HttpContext.User.Identity == null) throw new InvalidOperationException();

                if (!context.HttpContext.User.Identity.IsAuthenticated)
                {
                    //confere se o usuario esta logado, se nao estiver irá enviad-lo 
                    //para a tela de login, e após o usuario fazer o login
                    //ele envia para a pagina que o usuario estava tentando acessar
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(
                        new
                        {
                            area = "Identity", page = "/Account/Login",
                            ReturnUrl = context.HttpContext.Request.Path
                        }));
                }

                if (!CustomAuthorization.ValidateClaimsUser(context.HttpContext, _claim.Type, _claim.Value))
                {
                    //Verifica que, caso o usuario esteja logado, mas nao tem a claim
                    //necessaria para acessar aquela pagina, devolve um code 403 (Não autorizado)
                    context.Result = new StatusCodeResult(403);
                }
            }
        }

        public class ClaimsAuthorizeAttribute : TypeFilterAttribute
        {
            /*Aqui eu estou criando um atributo (decorator) para o ASP.Net
             * TypeFilterAttribute pois ele trabalha como um filtro
             *
             */
            public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
            {
                //Aqui eu defino que o filtro que eu vou trabalhar 
                //e do tipo RequisitoClaimFilter logo, do tipo IAuthorizationFilter
                //por herança.
                Arguments = [new Claim(claimName, claimValue)];
            }
        }
    }
}