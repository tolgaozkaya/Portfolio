using System;
namespace BlogWebProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ProjectURL { get; set; }


        public Project(int id, string title, string description, string link, string projectURL)
        {
            Id = id;
            Title = title;
            Description = description;
            Link = link;
            ProjectURL = projectURL;
        }
    }
}

