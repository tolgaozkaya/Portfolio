﻿using System;
namespace ServiceProject.ViewModels
{
    public class CommentVM
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PostId { get; set; }
    }
}

