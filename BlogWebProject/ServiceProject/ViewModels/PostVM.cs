using System;
using System.Collections.Generic;

namespace ServiceProject.ViewModels
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int CommentCount { get; set; }
        public List<CommentVM> Comments { get; internal set; }
    }
}

