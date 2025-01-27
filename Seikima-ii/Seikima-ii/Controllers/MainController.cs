using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seikima_ii.Data;
using Seikima_ii.Models;

namespace Seikima_ii.Controllers
{

    public class MainController : Controller
    {
        SeikimatsuContext db;
        Business business;
      

        public MainController()
        {

            db = new SeikimatsuContext();
            business = new Business(db);

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MainPage(int id)
        {
            return View(id);
        }

       public IActionResult Shop(int id)
        {
            return View(id);
        }

        public IActionResult bag(int id)
        {
            return View(id);
        }
    }
}
