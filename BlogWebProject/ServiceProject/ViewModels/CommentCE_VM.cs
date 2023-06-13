using System;
namespace ServiceProject.ViewModels
{
    public class CommentCE_VM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
    }
}

