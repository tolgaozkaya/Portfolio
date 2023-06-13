using System;
using System.Collections.Generic;
using System.Linq;
using ServiceProject.Models;
using ServiceProject.ViewModels;

namespace ServiceProject.Services
{
    public class PostService
    {
        private WebProjectContext _context;

        public PostService()
        {
            _context = new WebProjectContext();
        }
        public List<PostVM> GetPosts()
        {
            return _context.Posts
                .Select(p => new PostVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UserName = p.User.UserName,
                    CommentCount = p.Comments.Count
                })
                .ToList();
        }

        public PostVM GetPostById(int postId)
        {
            var post = _context.Posts
                .Where(p => p.Id == postId)
                .Select(p => new PostVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UserId = p.UserId,
                    UserName = p.User.UserName,
                    CommentCount = p.Comments.Count
                })
                .FirstOrDefault();

            return post ?? new PostVM();
        }

        public void CreatePost(PostCE_VM postViewModel, int userId)
        {

            var post = new Post
            {
                Title = postViewModel.Title,
                Content = postViewModel.Content,
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void UpdatePost(int postId, PostCE_VM postViewModel)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == postId);

            if (post != null)
            {
                post.Title = postViewModel.Title;
                post.Content = postViewModel.Content;

                _context.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == postId);

            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

    }

}
