﻿using System;
using System.Collections.Generic;

namespace ServiceProject.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
