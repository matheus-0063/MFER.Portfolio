using MFER.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MFER.App.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("erro/{id:length(3,3)}")]
    public IActionResult Errors(int id)
    {
        var modelErro = new ErrorViewModel();

        if (id == 500)
        {
            modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate o nosso suporte!";
            modelErro.Titulo = "Ocorreu um erro!";
            modelErro.ErroCode = id.ToString();
        }
        else if (id == 404)
        {
            modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvida !";
            modelErro.Titulo = "Ops! Página não encontrada!";
            modelErro.ErroCode = id.ToString();
        }
        else if (id == 403)
        {
            modelErro.Mensagem = "Você não tem permissão para fazer isso.";
            modelErro.Titulo = "Acesso negado";
            modelErro.ErroCode = id.ToString();
        }
        else
        {
            return StatusCode(500);
        }
        
        return View("Error", modelErro);
    }
}