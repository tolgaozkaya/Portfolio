using BlogWebProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServiceProject.Services;
using ServiceProject.ViewModels;

namespace BlogWebProject.Views
{
    public class UserController : Controller
    {
        private UserService _userService = new UserService();


        // GET: User
        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        // GET: User/Details/5
        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(userVM);
                return RedirectToAction(nameof(Index));
            }

            return View(userVM);
        }

        // GET: User/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserVM userVM)
        {
            if (id != userVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.UpdateUser(userVM);
                return RedirectToAction(nameof(Index));
            }

            return View(userVM);
        }

        // GET: User/Delete/5
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.RegisterUser(model);

                    return RedirectToAction("Index", "Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to register user: " + ex.Message);
                }
            }

            return View(model);
        }

    }
}
