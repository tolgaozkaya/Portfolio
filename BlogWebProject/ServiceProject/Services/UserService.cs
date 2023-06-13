using System.Collections.Generic;
using System.Linq;
using ServiceProject.Models;
using ServiceProject.ViewModels;

namespace ServiceProject.Services
{
    public class UserService
    {
        private WebProjectContext _context;

        public UserService()
        {
            _context = new WebProjectContext();
        }

        public List<UserVM> GetUsers()
        {
            var users = _context.Users
                .Select(u => new UserVM
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Password = u.Password,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    FullName = u.FirstName + " " + u.LastName
                })
                .ToList();

            return users;
        }

        public UserVM GetUserById(int id)
        {
            var user = _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserVM
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Password = u.Password,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    FullName = u.FirstName + " " + u.LastName
                })
                .FirstOrDefault();

            return user;
        }

        public void CreateUser(UserVM userVM)
        {
            var user = new User
            {
                Id = userVM.Id,
                UserName = userVM.UserName,
                Email = userVM.Email,
                Password = userVM.Password,
                FirstName = userVM.FirstName,
                LastName = userVM.LastName
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserVM userVM)
        {
            var user = _context.Users.Find(userVM.Id);

            if (user != null)
            {
                user.UserName = userVM.UserName;
                user.Email = userVM.Email;
                user.Password = userVM.Password;
                user.FirstName = userVM.FirstName;
                user.LastName = userVM.LastName;

                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void RegisterUser(UserVM registerModel)
        {
            // Create a new User instance
            var user = new User
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                Password = registerModel.Password,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
            };

            // Add the user to the context
            _context.Users.Add(user);

            // Save the changes to the database
            _context.SaveChanges();
        }
    }
}

