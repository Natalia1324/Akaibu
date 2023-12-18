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
        public HomeController(ILogger<HomeController> logger, DBAkaibuContext context)
        {
            _logger = logger;
            _context = context;

        }

        private Users getLoggedUser()
        {
            return HttpContext.Session.GetObject<Users>("LoggedUser");
        }

        public IActionResult Index()
        {

            return View(getLoggedUser());

        }

        public IActionResult Privacy()
        {

            return View(getLoggedUser());
        }

        public IActionResult Add_Anime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_Anime(DBAnime model, bool submitButtonClicked)
        {

            if (ModelState.IsValid)
            {
                // Sprawdź, czy anime o podanym tytule już istnieje
                var existingAnime = _context.DBAnime.FirstOrDefault(a => a.Title == model.Title);

                if (existingAnime != null)
                {
                    // Jeśli istnieje rekord o tej samej nazwie, zaktualizuj go
                    existingAnime.NumberOfEpisodes = model.NumberOfEpisodes;
                    existingAnime.Author = model.Author;
                    existingAnime.ShortStory = model.ShortStory;
                    existingAnime.Tag = model.Tag;
                    existingAnime.DateOfProductionStart = model.DateOfProductionStart;
                    existingAnime.DateOfProductionFinish = model.DateOfProductionFinish;
                    existingAnime.StatusAnime = model.StatusAnime;

                    _context.Update(existingAnime);
                }
                else
                {
                    var anime = new DBAnime
                    {
                        Title = model.Title,
                        NumberOfEpisodes = model.NumberOfEpisodes,
                        Author = model.Author,
                        ShortStory = model.ShortStory,
                        Tag = model.Tag,
                        DateOfProductionStart = model.DateOfProductionStart,
                        DateOfProductionFinish = model.DateOfProductionFinish,
                        StatusAnime = model.StatusAnime
                    };
                    _context.DBAnime.Add(anime);
                }
                // Dodaj anime do bazy danych

                _context.SaveChanges();

                return RedirectToAction("Index"); // Przekieruj gdziekolwiek po pomyślnym dodaniu
            }

            return View(model);

        }

        public IActionResult Account()
        {
            var loggedUser = getLoggedUser();

            if (loggedUser == null)
            {
                return View("Login");
            }

            if (loggedUser.isLogged)
            {

                return View(loggedUser);
            }
            else
            {
                return View("Login");

            }


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

            var model = new SearchResults
            {
                YourSearchResultsList = results
            };
            var logged = getLoggedUser();
            if (logged==null)
            {
                Users user = new();
                user.search = model;
                return View("SearchResults", user);
            }
            else
            {
                logged.search = model;
                return View("SearchResults", logged);
            }

           
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

            return View(); //zmiana

        }

        [HttpPost]
        public IActionResult Login(Users newUser)
        {
            var u = _context.Users
             .FirstOrDefault(u => u.Nick == newUser.Nick && u.Password == newUser.Password);

            if (u != null)
            {
                newUser.isLogged = true;
                var loggedUser = newUser;
                loggedUser.Id = u.Id;
                loggedUser.Login = u.Login;
                loggedUser.Ranks = u.Ranks;
                HttpContext.Session.SetObject("LoggedUser", loggedUser);
                return View("Index", loggedUser);

            }
            else
            {
                return View("Index", getLoggedUser());
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
            return View(getLoggedUser());
        }

        [HttpPost]
        public IActionResult Register(Users newUser)
        {

            var u = _context.Users
            .FirstOrDefault(u => u.Nick == newUser.Nick && u.Login == newUser.Login);

            if (u != null)
            {

                return View("Index", getLoggedUser());

            }
            else
            {

                newUser.Ranks = 1;
                _context.Users.Add(newUser);
                _context.SaveChanges();
                newUser.isLogged = true;
                var loggedUser = newUser;
                HttpContext.Session.SetObject("LoggedUser", loggedUser);
                return View("Index", loggedUser);

            }

        }

        public IActionResult Comments(int id)
        {
            var anime = _context.DBAnime.Include(a => a.Comments).ThenInclude(c => c.Users).FirstOrDefault(a => a.Id == id);

            if (anime == null)
            {
                return NotFound();
            }

            return View("Comments", anime);
        }

        [HttpPost]
        public IActionResult AddRatingAndComment(int animeId, int newRating, string newCommentText)
        {

            var loggedUser = getLoggedUser();

            if (loggedUser == null)
            {
                return View("Login");
            }

            if (loggedUser.isLogged)
            {

                var anime = _context.DBAnime.Find(animeId);


                if (anime != null)
                {

                    var newComment = new Comments
                    {
                        DateTheCommentWasAdded = DateTime.Now,
                        CommentText = newCommentText,
                        MyRating = newRating.ToString(),
                        Users = loggedUser,
                        UsersId = loggedUser.Id,
                        DBAnimeId = anime.Id
                    };

                    _context.Comments.Add(newComment);

                    _context.SaveChanges();

                    return Comments(animeId);
                }
                else
                {
                    return NotFound("Anime not found");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult AddToFinishedList(DBAnime anime)
        {
            var logged = getLoggedUser();
            Status status = new Status();
            status.UsersId = logged.Id;
            status.DBAnimeId = anime.Id;
            status.LastEpizod = 0;
            status.StatusValue = "Finished";
            _context.Status.Add(status);
            _context.SaveChanges();

            return View("Index"); 
        }

        [HttpPost]
        public IActionResult AddToCurrentlyWatchedList(DBAnime anime)
        {

            var logged = getLoggedUser();
            Status status = new Status();
            status.UsersId = logged.Id;
            status.DBAnimeId = anime.Id;
            status.LastEpizod = 0;
            status.StatusValue = "Watched";
            _context.Status.Add(status);
            _context.SaveChanges();

            return View("Index");  
        }

        [HttpPost]
        public IActionResult AddToPlannedList(DBAnime anime)
        {

        var logged = getLoggedUser();
        Status status=new Status();
            status.UsersId = logged.Id;
            status.DBAnimeId = anime.Id;
            status.LastEpizod = 0;
            status.StatusValue = "Planned";
            _context.Status.Add(status);
            _context.SaveChanges();

            return View("Index");
        }

        public IActionResult Lists()
        {
            var loggedUser = getLoggedUser();


            ListsModel model;

           
                var userEmail = loggedUser.Login;


                var user = _context.Users
                .Include(u => u.Status)
                .FirstOrDefault(u => u.Login == userEmail);

            model = new ListsModel
            {
                Finished = _context.Users
                .Where(u => u.Nick == loggedUser.Nick && u.Status.Any(s => s.StatusValue == "Finished"))
                .SelectMany(u => u.Status.Where(s => s.StatusValue == "Finished"))
                .Select(s => new StatusModel
                {
                    LastEpizod = s.LastEpizod,
                   StatusValue = s.StatusValue,
                    AnimeAuthor = s.DBAnime != null ? s.DBAnime.Author : "N/A",
                  AnimeTitle = s.DBAnime != null ? s.DBAnime.Title : "N/A"
                })
        .ToList(),
                Watched = _context.Users
                .Where(u => u.Nick == loggedUser.Nick && u.Status.Any(s => s.StatusValue == "Watched"))
                .SelectMany(u => u.Status.Where(s => s.StatusValue == "Watched"))
                .Select(s => new StatusModel
                {
                    LastEpizod = s.LastEpizod,
                    StatusValue = s.StatusValue,
                    AnimeAuthor = s.DBAnime != null ? s.DBAnime.Author : "N/A",
                    AnimeTitle = s.DBAnime != null ? s.DBAnime.Title : "N/A"
                })
        .ToList(),
                Planned = _context.Users
                .Where(u => u.Nick == loggedUser.Nick && u.Status.Any(s => s.StatusValue == "Planned"))
                .SelectMany(u => u.Status.Where(s => s.StatusValue == "Planned"))
                .Select(s => new StatusModel
                {
                    LastEpizod = s.LastEpizod,
                    StatusValue = s.StatusValue,
                    AnimeAuthor = s.DBAnime != null ? s.DBAnime.Author : "N/A",
                    AnimeTitle = s.DBAnime != null ? s.DBAnime.Title : "N/A"
                })
        .ToList()
            };
            

            loggedUser.lists = model;
            
                return View("Lists", loggedUser);

           
          




        }


    }
}
