using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogWebProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogWebProject.Controllers
{
    public class ProjectsController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var projects = new List<Project>();

            projects.Add(new Project(1, "HRMS-Backend", "Java Project", "img/hrms.png", "https://github.com/tolgaozkaya/hrms-backend"));
            projects.Add(new Project(2, "Rent A Car", "C#- WinForms Application Project", "img/rentacar.png", "https://github.com/tolgaozkaya/RentACarProject"));
            projects.Add(new Project(4, "First Web Project", "First Website", "img/website.png", "https://github.com/tolgaozkaya/WebProject"));
            projects.Add(new Project(3, "Cisco Project", "Networking Project", "img/network.png", "https://github.com/tolgaozkaya/Networking-Project"));


            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

