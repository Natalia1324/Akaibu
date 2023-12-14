//using Akaibu_Project.Data;
using Akaibu_Project.Entions;
using Akaibu_Project.Entities;
using Akaibu_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;




namespace Akaibu_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBAkaibuContext _context;
        private Users loggedUser;
        public HomeController(ILogger<HomeController> logger, DBAkaibuContext context)
        {
            _logger = logger;
            _context = context;
            loggedUser = new Users();

        }

        public IActionResult Index()
        {
            
            return View(loggedUser);
            
        }

        public IActionResult Privacy()
        {
            
            return View(loggedUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search(string query, string tag)
        {
            var tagList = tag?.Split(',').Select(t => t.Trim()).ToList();

            var results = _context.DBAnime
                .Where(a => string.IsNullOrEmpty(query) || a.Title.Contains(query) || a.ShortStory.Contains(query))
                .ToList()
                .Where(a => tagList == null || tagList.All(t => a.Tag.Contains(t)))
                .ToList();

            // Utwórz model wyników wyszukiwania
            var model = new SearchResults
            {
                YourSearchResultsList = results
            };

            // Przekieruj do widoku z wynikami wyszukiwania
            return View("SearchResults", model);
        }

        public IActionResult AnimeDetails(int id)
        {
            var anime = _context.DBAnime.Find(id);

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        public IActionResult Login()
        {
           
            return View(loggedUser);

        }

        [HttpPost]
        public IActionResult Login(Users newUser)
        {
            var u = _context.Users
             .FirstOrDefault(u => u.Nick == newUser.Nick && u.Password == newUser.Password);

            if (u != null)
            {
                newUser.isLogged = true;
                loggedUser = newUser;
                HttpContext.Session.SetObject("LoggedUser", loggedUser);
                return View("Index", loggedUser);

            }
            else
            {


                return View("Index", loggedUser);
            }
        }

        [HttpPost]
        [Route("/Home/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedUser");
            return Ok(); 
        }

        public IActionResult Register()
        {
            return View(loggedUser);
        }

        [HttpPost]
        public IActionResult Register(Users newUser)
        {
            
            var u = _context.Users
            .FirstOrDefault(u => u.Nick == newUser.Nick && u.Login == newUser.Login);

            if (u!=null)
                {
                    
                    
                    return View("Index", loggedUser);
                    
                }
                else
                {
            
                    newUser.Ranks = 1;
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    newUser.isLogged = true;
                    loggedUser = newUser;
                HttpContext.Session.SetObject("LoggedUser", loggedUser);
                return View("Index", loggedUser);
                }
            
           
        }

        public IActionResult Lists()
        {
            List<Status> FinishedEmpty = new();
            List<Status> WatchedEmpty = new();
            List<Status> PlannedEmpty = new();
            if (User.Identity.IsAuthenticated)
            {
                var userEmail = User.Identity.Name;


                var user = _context.Users
                .Include(u => u.Status)
                .FirstOrDefault(u => u.Login == userEmail);
                
                    var viewModel = new ListsModel
                    {
                        Finished = user.Status.Where(s => s.StatusValue == "Finished").ToList(),
                        Watched = user.Status.Where(s => s.StatusValue == "Watched").ToList(),
                        Planned = user.Status.Where(s => s.StatusValue == "Planned").ToList()
                    };
                    return View("Lists", viewModel);
               
            }
            else
            {
                var emptyModel = new ListsModel
                {
                    Finished = FinishedEmpty,
                    Watched = WatchedEmpty,
                    Planned = PlannedEmpty
                };
                return View("Lists", emptyModel);
            }

            


        }


    }
}
