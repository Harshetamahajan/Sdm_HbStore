using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Emstore.Models;

using BOL;
using SAL;

namespace Emstore.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

   [HttpPost]
     public IActionResult Login(string email,string password)
    {
        Credentials loggedInUser=new Credentials(){UserId=email,Password=password};
        AccountService asv=new AccountService();
         if(asv.LoginCheck(loggedInUser)==true)
                   Response.Redirect("/Orders/Index");

       return View();
    }

    

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
