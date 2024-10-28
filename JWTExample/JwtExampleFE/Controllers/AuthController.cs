using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Protected()
    {
        return View();
    }
}
