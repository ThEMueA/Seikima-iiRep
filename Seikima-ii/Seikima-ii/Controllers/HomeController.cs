using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seikima_ii.Data;
using Seikima_ii.Models;

namespace Seikima_ii.Controllers
{
    public class HomeController : Controller
    {
        SeikimatsuContext db;
        Business business;
      

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            db = new SeikimatsuContext();
            business = new Business(db);

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Id,Fname,Lname,Username,Password,UserImg")] User user)
        {

            if (ModelState.IsValid)
            {
                User? existingUser = db.Users.FirstOrDefault(u => u.Username.Equals(user.Username));
                if (existingUser != null)
                {


                    if (user.Password.Equals(existingUser.Password))
                    {
                        if(user.Username=="Master")
                            return RedirectToAction( "CRUD", "Master");


                        int id = existingUser.Id;
                        return RedirectToAction("MainPage", "Main", new { id = id});
                    }
                 
                }
                return RedirectToAction("Register", "Home");
            }
            return View(user);
        }


        public IActionResult Register()
        {
            return View();
        }


       [HttpPost]
        public IActionResult Register([Bind("Id,Fname,Lname,Username,Password,UserImg")] User user)
        {
            if (ModelState.IsValid)
            {

                User? existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser == null)
                {
                    int d;
                   List<User> list = business.GetUsers();
                    d =list.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    d++;
                    user.Id = d;
                    business.AddUser(user);

                    return RedirectToAction("MainPage", "Main", new { id = user.Id });

                }
                return RedirectToAction("Index");

            }

            return View(user);

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
