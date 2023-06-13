using System;
namespace ServiceProject.ViewModels
{
	public class UserVM
	{
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }
    }
}

