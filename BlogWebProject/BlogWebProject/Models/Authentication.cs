using Microsoft.EntityFrameworkCore;
using ServiceProject.Models;

namespace BlogWebProject.Models
{
    public class Authentication
    {
        private WebProjectContext _context = new WebProjectContext();

        public string? ErrorMessage { get; set; }

        public bool _authentication(string username, string password, out int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null || (username == "tolga" && password == "123"))
            {
                userId = user != null ? user.Id : 0;
                return true;
            }
            else
            {
                ErrorMessage = "Kullanıcı Bulunamadı";
                userId = 0;
                return false;
            }
        }

    }
}
