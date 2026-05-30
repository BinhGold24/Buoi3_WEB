using Buoi3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi3.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
    
            if (model.Username == "admin" && model.Password == "123")
            {
                ViewBag.Message = "Login success";
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.Message = "Login failed";
                ViewBag.IsSuccess = false;
            }

            return View(model);
        }
    }
}