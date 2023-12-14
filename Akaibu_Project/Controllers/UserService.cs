using Akaibu_Project.Entions;
using Akaibu_Project.Entities;
using System;
using System.Linq;

namespace Akaibu_Project.Services
{
    public class UserService
    {
        private readonly DBAkaibuContext _context;

        public UserService(DBAkaibuContext context)
        {
            _context = context;
        }

        public bool RegisterUser(Users user)
        {
            // Check if the user with the same login already exists
            if (_context.Users.Any(u => u.Login == user.Login))
            {
                // User with the same login already exists
                return false;
            }

            // Add the new user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }

        public Users AuthenticateUser(string login, string password)
        {
            // Find the user with the provided login and password
            var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            // Return the authenticated user or null if not found
            return user;
        }
    }
}
