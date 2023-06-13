using System;
using System.Collections.Generic;
using System.Linq;
using ServiceProject.Models;
using ServiceProject.ViewModels;

namespace ServiceProject.Services
{
    public class CommentService
    {
        private WebProjectContext _context;

        public CommentService()
        {
            _context = new WebProjectContext();
        }

        public List<CommentVM> GetCommentsByPostId(int postId)
        {
            return _context.Comments
                .Where(c => c.PostId == postId)
                .Select(c => new CommentVM
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    UserName = c.User.UserName
                })
                .ToList();
        }

        public CommentVM GetCommentById(int commentId)
        {
            var comment = _context.Comments
                .Where(c => c.Id == commentId)
                .Select(c => new CommentVM
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    UserId = c.UserId,
                    UserName = c.User.UserName,
                    PostId=c.PostId
                })
                .FirstOrDefault();

            return comment ?? new CommentVM();
        }

        public void CreateComment(CommentCE_VM commentViewModel, int userId)
        {
            var comment = new Comment
            {
                PostId = commentViewModel.PostId,
                Content = commentViewModel.Content,
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(int commentId, CommentCE_VM commentViewModel)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment != null)
            {
                comment.Content = commentViewModel.Content;

                _context.SaveChanges();
            }
        }

        public void DeleteComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}
