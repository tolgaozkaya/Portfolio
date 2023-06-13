using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceProject.Models;
using ServiceProject.Services;
using ServiceProject.ViewModels;
using System.Threading.Tasks;

namespace BlogWebProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService _commentService;
        private readonly WebProjectContext _context;

        public CommentController()
        {
            _commentService = new CommentService();
            _context = new WebProjectContext();
        }

        public IActionResult Index(int? postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            var comments = _commentService.GetCommentsByPostId(postId.Value);
            if (comments == null)
            {
                return NotFound();
            }

            var commentVMs = comments.Select(c => new CommentVM
            {
                Id = c.Id,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                UserName = c.UserName
            }).ToList();

            return View(commentVMs);
        }

        // GET: Comment/Create
        public IActionResult Create(int postId)
        {
            var commentViewModel = new CommentCE_VM
            {
                PostId = postId
            };

            return View(commentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommentCE_VM commentViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserSession");

                int newUserId = int.Parse(userId);

                _commentService.CreateComment(commentViewModel, newUserId);
                return RedirectToAction("Details", "Blog", new { id = commentViewModel.PostId });
            }

            return View(commentViewModel);
        }


        public IActionResult Edit(int id)
        {
            string userId = HttpContext.Session.GetString("UserSession");

            int newUserId = int.Parse(userId);

            var comment = _commentService.GetCommentById(id);
            if (comment == null || comment.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction(nameof(Index));
            }

            var commentVM = new CommentCE_VM
            {
                Id = comment.Id,
                Content = comment.Content
            };

            return View(commentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CommentCE_VM commentViewModel)
        {
            string userId = HttpContext.Session.GetString("UserSession");

            int newUserId = int.Parse(userId);

            var comment = _commentService.GetCommentById(id);
            int? currentPostId = comment.PostId;

            if (comment == null || comment.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction("Index", "Comment", new { postId = currentPostId });
            }

            if (ModelState.IsValid)
            {
                _commentService.UpdateComment(id, commentViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(commentViewModel);
        }

        public IActionResult Details(int id)
        {
            var comment = _commentService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            var commentViewModel = new CommentVM
            {
                Id = comment.Id,
                Content = comment.Content,
                UserName = comment.UserName,
                CreatedAt = comment.CreatedAt
            };

            return View(commentViewModel);
        }

        public IActionResult Delete(int id)
        {
            string userId = HttpContext.Session.GetString("UserSession");

            int newUserId = int.Parse(userId);
            var comment = _commentService.GetCommentById(id);

            int? currentPostId = comment.PostId;


            if (comment == null || comment.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction("Index", "Comment", new { postId = currentPostId }); ;
            }

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            string userId = HttpContext.Session.GetString("UserSession");

            int newUserId = int.Parse(userId);

            var comment = _commentService.GetCommentById(id);
            int? currentPostId = comment.PostId;

            if (comment == null || comment.UserId != newUserId)
            {
                TempData["Mesaj"] = "Bu işlemi yapmaya yetkiniz yok";
                return RedirectToAction("Index", "Comment", new { postId = currentPostId });
            }

            _commentService.DeleteComment(id);
            return RedirectToAction("Index", "Comment", new { postId = currentPostId }); ;
        }

    }
}
