using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueBud.Controllers;

public class MainPageController : Controller
{
    // GET
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    
}