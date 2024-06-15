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
using Microsoft.AspNetCore.Mvc.Rendering;




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


        //[HttpPost]
        //[Route("Anime/CreateWithEpisodes")]
        //public IActionResult CreateWithEpisodes(DBAnime anime, List<Episods> episodes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var episode in episodes)
        //        {
        //            episode.DBAnime = anime;
        //            anime.Episods.Add(episode);
        //        }

        //        _context.DBAnime.Add(anime);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index"); // Redirect to the list of animes or another relevant page
        //    }

        //    return View(anime);
        //}

        [HttpPost]
        [Route("Anime/CreateWithEpisodes")]
        public IActionResult CreateWithEpisodes(DBAnime anime, List<Episods> episodes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var episode in episodes)
                    {
                        episode.DBAnime = anime;
                        anime.Episods.Add(episode);
                    }

                    _context.DBAnime.Add(anime);
                    _context.SaveChanges();
                    return RedirectToAction("Index"); // Redirect to the list of animes or another relevant page
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use any logging framework you prefer)
                    _logger.LogError(ex, "An error occurred while creating anime with episodes.");

                    // Optionally, add a model error to provide feedback to the user
                    ModelState.AddModelError("", "An error occurred while creating the anime. Please try again later.");
                }
            }

            return View(anime);
        }


        public IActionResult Add_Episode()
        {
            ViewBag.Animes = _context.DBAnime.ToList();
            return View();
        }

        //[HttpPost]
        //public IActionResult Add_Episode(AnimeViewModel model)
        //{
        //    if (model != null)
        //    {
        //        foreach (var episode in model.Episodes)
        //        {
        //            episode.Id = Guid.NewGuid();
        //            _context.Episods.Add(episode);
        //        }
        //        _context.SaveChanges();
        //        return RedirectToAction("Index"); // lub inna akcja po pomyślnym dodaniu
        //    }

        //    ViewBag.Animes = new SelectList(_context.DBAnime, "Id", "Title");
        //    return View(model);
        //}
        
        
        [HttpPost]
        public IActionResult Add_Episode(AnimeViewModel model)
        {
            if (model != null)
            {
                try
                {
                    foreach (var episode in model.Episodes)
                    {
                        episode.Id = Guid.NewGuid();
                        _context.Episods.Add(episode);
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index"); // lub inna akcja po pomyślnym dodaniu
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use any logging framework you prefer)
                    _logger.LogError(ex, "An error occurred while adding episodes.");

                    // Optionally, add a model error to provide feedback to the user
                    ModelState.AddModelError("", "An error occurred while adding the episodes. Please try again later.");
                }
            }

            ViewBag.Animes = new SelectList(_context.DBAnime, "Id", "Title");
            return View(model);
        }


        //[HttpPost]
        //public async Task<IActionResult> Add_Episode(Episods episode)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        episode.Id = Guid.NewGuid();
        //        _context.Episods.Add(episode);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ViewBag.Animes = _context.DBAnime.ToList();
        //    return View(episode);
        //}

        public IActionResult Account()
        {
            var loggedUser = getLoggedUser();
            
            if (loggedUser == null)
            {
                return View("Login");
            }

            if (loggedUser.isLogged)
            {
                AccountModel model = new AccountModel
                {
                    user = loggedUser,
                    FinishedCount = _context.Users
                    .Where(u => u.Nick == loggedUser.Nick)
                    .SelectMany(u => u.Status)
                    .Count(s => s.StatusValue == "Finished"),
                        WatchedCount = _context.Users
                    .Where(u => u.Nick == loggedUser.Nick)
                    .SelectMany(u => u.Status)
                    .Count(s => s.StatusValue == "Watched"),
                        PlannedCount = _context.Users
                    .Where(u => u.Nick == loggedUser.Nick)
                    .SelectMany(u => u.Status)
                    .Count(s => s.StatusValue == "Planned")
                };
                //Console.WriteLine("Ilosc ukonczonych: "+loggedUser.lists.Finished.Count);
                return View(model);
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
                .Where(a => string.IsNullOrEmpty(query)
                            || a.Title.ToLower().Contains(query.ToLower())
                            || a.ShortStory.ToLower().Contains(query.ToLower()))
                .ToList()
                .Where(a => tagList == null
                            || tagList.All(t => a.Tag.ToLower().Contains(t.ToLower())))
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
            var anime = _context.DBAnime.Include(a => a.Comments).ThenInclude(c => c.Users).Include(a => a.Episods).FirstOrDefault(a => a.Id == id);
            
            Console.WriteLine("Ilosc odcinkow: " + anime.Episods.Count);
            foreach (var episode in anime.Episods)
            {
                Console.WriteLine("Odcinek " + episode.Number);
            }
            
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

        //[HttpPost]
        //public IActionResult ChangePassword(string newPassword)
        //{
        //    Console.WriteLine("Zmieniam haslo na: " + newPassword );
        //    var loggedUser = getLoggedUser();

        //    if (loggedUser != null && newPassword != null)
        //    {
        //        // Zmień hasło użytkownika.
        //        loggedUser.Password = newPassword;

        //        // Zapisz zmiany w bazie danych
        //        _context.Update(loggedUser);
        //        _context.SaveChanges();
        //        Logout();

        //    }

        //   return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult ChangePassword(string newPassword)
        {
            try
            {
                //Console.WriteLine("Zmieniam haslo na: " + newPassword);
                var loggedUser = getLoggedUser();

                if (loggedUser == null)
                {
                    TempData["ErrorMessage"] = "User not logged in.";
                    return RedirectToAction("Index");
                }

                if (string.IsNullOrEmpty(newPassword))
                {
                    TempData["ErrorMessage"] = "Password cannot be empty.";
                    return RedirectToAction("Index");
                }

                // Minimalna długość hasła - przykład: 8 znaków
                const int minLength = 8;

                if (newPassword.Length < minLength)
                {
                    TempData["ErrorMessage"] = $"Password must be at least {minLength} characters long.";
                    return RedirectToAction("Index");
                }

                // Maksymalna długość hasła - przykład: 20 znaków
                const int maxLength = 20;

                if (newPassword.Length > maxLength)
                {
                    TempData["ErrorMessage"] = $"Password must not exceed {maxLength} characters.";
                    return RedirectToAction("Index");
                }

                // Aktualizacja hasła użytkownika
                loggedUser.Password = newPassword;

                // Zapisz zmiany w bazie danych
                _context.Update(loggedUser);
                _context.SaveChanges();
                Logout();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Obsługa błędów, np. logowanie błędu
                Console.WriteLine("An error occurred while changing password: " + ex.Message);

                TempData["ErrorMessage"] = "An error occurred while changing password.";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult BanReason(int userId)
        {
            var user = _context.Users.Find(userId); ; // Metoda do pobrania użytkownika z bazy danych
            if (user == null)
            {
                return View("Index");
            }

            var model = new BanReasonViewModel
            {
                UserId = userId
            };

            return View(model);
        }

        // Akcja do obsługi wysłania formularza
        [HttpPost]
        public IActionResult ProcessBanReasonForm(BanReasonViewModel model)
        {
            if (model != null)
            {
                var user = _context.Users.Find(model.UserId); ; // Metoda do pobrania użytkownika z bazy danych
                if (user == null)
                {
                   // return View("Error");
                }

                BanUser(model.UserId, model.Reason);

                //user.Ranks = 69;
                
                //user.Bans = model.Reason; // Dodanie powodu bana
                //Console.WriteLine("powód bana: " + model.Reason);
                //_context.Update(user);// Metoda do zapisania zmian w bazie danych

                return RedirectToAction("Index"); // Przekierowanie po zapisaniu
            }
            return View("Error");
        }
        [HttpPost]
        public IActionResult BanUser(int userId, string reason)
        {
            var loggedUser = getLoggedUser();

            // Sprawdź, czy użytkownik ma uprawnienia admina
            if (loggedUser != null && loggedUser.Ranks == 1)
            {
                // Pobierz użytkownika do zbanowania
                var userToBan = _context.Users.Find(userId);

                // Sprawdź, czy użytkownik istnieje
                if (userToBan != null)
                {
                    // Zmień rangę użytkownika na 69 (lub inną wybraną)
                    userToBan.Ranks = 69;
                    userToBan.Bans = reason;

                    // Zapisz zmiany w bazie danych
                    _context.Update(userToBan);
                    _context.SaveChanges();
                }

                // Przekieruj z powrotem do panelu admina lub gdziekolwiek indziej
                return RedirectToAction("Privacy");
            }
            else
            {
                // Jeśli użytkownik nie ma uprawnień admina, możesz przekierować go
                // gdzie indziej lub wyświetlić komunikat o braku uprawnień
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult UnbanUser(int userId)
        {
            var loggedUser = getLoggedUser();

            // Sprawdź, czy użytkownik ma uprawnienia admina
            if (loggedUser != null && loggedUser.Ranks == 1)
            {
                // Pobierz użytkownika do zbanowania
                var userToUnBan = _context.Users.Find(userId);

                // Sprawdź, czy użytkownik istnieje
                if (userToUnBan != null)
                {
                    userToUnBan.Ranks = 0;

                    // Zapisz zmiany w bazie danych
                    _context.Update(userToUnBan);
                    _context.SaveChanges();
                }

                // Przekieruj z powrotem do panelu admina lub gdziekolwiek indziej
                return RedirectToAction("Privacy");
            }
            else
            {
                // Jeśli użytkownik nie ma uprawnień admina, możesz przekierować go
                // gdzie indziej lub wyświetlić komunikat o braku uprawnień
                return RedirectToAction("Index");
            }
        }
        //[HttpPost]
        public IActionResult Panel()
        {

            var loggedUser = getLoggedUser();

            // Przykład sprawdzenia, czy użytkownik ma uprawnienia admina
            if (loggedUser != null && loggedUser.Ranks == 1)
            {
                // Przykładowe dane dla raportów
                var reportsData = _context.Reports.ToList();

                // Przykładowe dane dla użytkowników
                var usersData = _context.Users.ToList();

                // Przekaż dynamiczny model do widoku
                ViewBag.PanelData = new { Reports = reportsData, Users = usersData };

                return View();

            }
            else
            {
                // Jeśli użytkownik nie ma uprawnień admina, możesz przekierować go
                // gdzie indziej lub wyświetlić komunikat o braku uprawnień
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult BanPage()
        {

            var loggedUser = getLoggedUser();

            // Przykład sprawdzenia, czy użytkownik ma uprawnienia admina
            if (loggedUser != null && loggedUser.Ranks == 69)
            {

                return View(loggedUser);// loggedUser.Bans

            }
            else
            {
                // Jeśli użytkownik nie ma uprawnień admina, możesz przekierować go
                // gdzie indziej lub wyświetlić komunikat o braku uprawnień
                return RedirectToAction("Index", "Home");
            }
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
                loggedUser.Bans = u.Bans;
                HttpContext.Session.SetObject("LoggedUser", loggedUser);
                return View("Index", loggedUser);

            }
            else
            {
                //return View("Index", getLoggedUser());
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
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
            .FirstOrDefault(u => (u.Nick == newUser.Nick && u.Login == newUser.Login) || u.Login == newUser.Login);

            if (u != null)
            {
                ModelState.AddModelError(string.Empty, "The user is already registered");
                return View();

            }
            else
            {

                newUser.Ranks = 0;
                _context.Users.Add(newUser);
                _context.SaveChanges();
                newUser.isLogged = true;
                var loggedUser = newUser;
                HttpContext.Session.SetObject("LoggedUser", loggedUser);
                return View("Index", loggedUser);

            }

        }
        public IActionResult SendReport()
        {
            return (View());
        }
        [HttpPost]
        public IActionResult SendReport(string reportText)
        {
            // Tutaj możesz dodać obiekt raportu do kolekcji lub bazy danych
            // Przykład: Raports.dodajRaport(raport);

            // Możesz wykonać inne operacje po dodaniu raportu

            // Przekierowanie na inną stronę lub powrót do strony głównej
            var raport = new Reports
            {
                ReportText = reportText,
                DateTheReportWasAdded = DateTime.Now,
                UsersId = getLoggedUser().Id,
                DBAnimeId = 1
            };
            _context.Reports.Add(raport);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
        public IActionResult AddRatingAndComment(int animeId, int newRating, int episodeNumber, string newCommentText)
        {

            var loggedUser = getLoggedUser();

            if (loggedUser == null)
            {
                return View("Login");
            }

            if (loggedUser.isLogged)
            {

                var anime = _context.DBAnime.Find(animeId);
                var episode = _context.Episods.FirstOrDefault(e => e.Number == episodeNumber && e.DBAnimeId == animeId);

                if (anime != null && episode != null)
                {
                    var newComment = new Comments
                    {
                        DateTheCommentWasAdded = DateTime.Now,
                        CommentText = newCommentText,
                        MyRating = newRating.ToString(),
                        //Users = loggedUser,
                        UsersId = loggedUser.Id,
                        DBAnimeId = anime.Id,
                        EpisodsId = episode.Id
                    };
                    newComment.Episods = episode;
                    _context.Entry(newComment.Episods).State = EntityState.Unchanged;

                    _context.Comments.Add(newComment);
                    _context.SaveChanges();

                    return Comments(animeId);
                }
                else
                {
                    return NotFound("Anime or episode not found");
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
            status.EpisodsId = null;
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
            status.EpisodsId = null;
            //status.Episods.Number = 0;
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
            status.EpisodsId = null;
            //status.Episods.Number = 0;
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
                    LastEpizod = s.Episods.Number,
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
                    LastEpizod = s.Episods.Number,
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
                    LastEpizod = s.Episods.Number,
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
