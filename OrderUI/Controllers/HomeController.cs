using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}