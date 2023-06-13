using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceProject.Models;
using ServiceProject.Services;
using ServiceProject.ViewModels;

namespace BlogWebProject.Controllers
{
    public class BlogController : BaseController
    {
        private readonly PostService _postService;
        private readonly CommentService _commentService;

        public BlogController()
        {
            _postService = new PostService();
            _commentService = new CommentService();
        }

        public IActionResult Index()
        {
            var posts = _postService.GetPosts();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostCE_VM postViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserSession");
                if (string.IsNullOrEmpty(userId))
                {
                    TempData["Mesaj"] = "Kullanıcı oturum açmamış";
                    return RedirectToAction(nameof(Index));
                }

                int newUserId = int.Parse(userId);

                _postService.CreatePost(postViewModel, newUserId);
                return RedirectToAction(nameof(Index));
            }

            return View(postViewModel);
        }

        public IActionResult Edit(int id)
        {
            string userId = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Mesaj"] = "Kullanıcı oturum açmamış";
                return RedirectToAction(nameof(Index));
            }

            int newUserId = int.Parse(userId);

            var post = _postService.GetPostById(id);
            if (post == null || post.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction(nameof(Index));
            }

            var postViewModel = new PostCE_VM
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };

            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, PostCE_VM postViewModel)
        {
            string userId = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Mesaj"] = "Kullanıcı oturum açmamış";
                return RedirectToAction(nameof(Index));
            }

            int newUserId = int.Parse(userId);

            var post = _postService.GetPostById(id);
            if (post == null || post.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                _postService.UpdatePost(id, postViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(postViewModel);
        }

        public IActionResult Delete(int id)
        {
            string userId = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Mesaj"] = "Kullanıcı oturum açmamış";
                return RedirectToAction(nameof(Index));
            }

            int newUserId = int.Parse(userId);

            var post = _postService.GetPostById(id);
            if (post == null || post.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            string userId = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Mesaj"] = "Kullanıcı oturum açmamış";
                return RedirectToAction(nameof(Index));
            }

            int newUserId = int.Parse(userId);

            var post = _postService.GetPostById(id);
            if (post == null || post.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction(nameof(Index));
            }

            _postService.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
