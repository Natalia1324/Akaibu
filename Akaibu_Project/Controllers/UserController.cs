using Akaibu_Project.Entions;
using Akaibu_Project.Entities;
using Akaibu_Project.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Akaibu_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                bool registrationSuccess = _userService.RegisterUser(user);

                if (registrationSuccess)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Login", "User with the same email already exists");
                }
            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            var authenticatedUser = _userService.AuthenticateUser(login, password);

            if (authenticatedUser != null)
            {
                // Store user information in a session or cookie and redirect to the dashboard
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("Login", "Invalid login or password");
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            // Add code to display the user dashboard
            return View();
        }
    }
}
   