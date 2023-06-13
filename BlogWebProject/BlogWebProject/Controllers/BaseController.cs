using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogWebProject.Controllers
{
    public class BaseController : Controller
    {

        public bool IsSessionAlive()
        {
            var value = HttpContext.Session.GetString("UserSession");
            if (value == null)
            {
                return false;
            }
            else
                return true;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (IsSessionAlive() == false)
            {
                TempData["Mesaj"] = "Bu sayfayı görüntülemek için giriş yapınız..";
                context.Result = RedirectToAction("Index", "Login");
                return;
            }
        }
    }
}

