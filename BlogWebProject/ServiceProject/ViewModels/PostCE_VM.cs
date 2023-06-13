using System;
namespace ServiceProject.ViewModels
{
    public class PostCE_VM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
    }
}
