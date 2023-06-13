using Microsoft.AspNetCore.Mvc;
using BlogWebProject.Models;

namespace BlogWebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginVM loginVM)
        {
            Authentication authentication = new Authentication();

            if (authentication._authentication(loginVM.UserName, loginVM.Password, out int userId))
            {
                TempData["Mesaj"] = "Giriş Başarılı";
                HttpContext.Session.SetString("UserSession", userId.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Mesaj"] = authentication.ErrorMessage;
            }

            return View();
        }

    }
}

