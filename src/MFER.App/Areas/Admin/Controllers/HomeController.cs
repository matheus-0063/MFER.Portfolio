using Microsoft.AspNetCore.Mvc;

namespace MFER.App.Areas.Admin.Controllers;

[Area("Admin")]
[Route("home")]
public class HomeController : Controller
{
    [HttpGet("index")]
    public IActionResult Index()
    {
        return View();
    }
}