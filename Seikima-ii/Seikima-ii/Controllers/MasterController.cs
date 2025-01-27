using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seikima_ii.Data;
using Seikima_ii.Models;

namespace Seikima_ii.Controllers
{
    public struct golqmadanna()
    {
      public List<User> users;
        public List<Concert> concert;
        public List<Country> country;
        public List<GoodDeal> goodDeal;
        public List<Order> order;
    }

    public class MasterController : Controller
    {
        SeikimatsuContext db;
        Business business;

        public MasterController()
        {

            db = new SeikimatsuContext();
            business = new Business(db);

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CRUD()
        {
            golqmadanna danna = new golqmadanna();
            danna.users = business.GetUsers();
            danna.country = business.getCountries();
            danna.concert = business.getCousert();
            danna.goodDeal = business.GetDeals();
            danna.order = business.GetOrders();
            return View(danna);
        }

        public IActionResult DeleteUser(int id)
        {
            business.DeleteUserById(id);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }

        public IActionResult DeleteDeal(int id)
        {
            business.DeleteDealById(id);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }


        public IActionResult DeleteConcert(int id)
        {
            business.DeleteCounsetyById(id);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }


        public IActionResult DeleteCountry(string id)
        {
            business.DeleteCountryById(id);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }

        public IActionResult DeleteOrder(int id)
        {
            business.DeleteOrderById(id);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }




        public IActionResult EditUser(int id)
        {
            User user = business.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(int id ,[Bind("Id,Fname,Lname,Username,Password,UserImg")] User user)
        {
            
            if(ModelState.IsValid)
            {
              
                db.Update(user);
               await db.SaveChangesAsync();
                return RedirectToAction("CRUD");
            }
            return View(user);
        }


        public IActionResult EditDeal(int id)
        {
            GoodDeal deal = business.GetDealById(id);
            return View(deal);
        }

        [HttpPost]
        public async Task<IActionResult> EditDeal(int id, [Bind("Id,ItemName,Price,Description,ItemImgPath")] GoodDeal deal)
        {
 
            if (ModelState.IsValid)
            {
              
                db.Update(deal);
                await db.SaveChangesAsync();
                return RedirectToAction("CRUD");
            }
            return View(deal);
        }


        public IActionResult EditConcert(int id)
        {
            Concert co = business.GetConsertByid(id);
            return View(co);
        }

        [HttpPost]
        public async Task<IActionResult> EditConcert(int id, [Bind("ConcertId,CountryCode,Name,Date,Program,ImgPath")] Concert co)
        {


            if (ModelState.IsValid)
            {
                co.ConcertId = id;
                db.Update(co);
                await db.SaveChangesAsync();
                return RedirectToAction("CRUD");
            }
            return View(co);
        }


        public IActionResult EditCountry(string id)
        {
            Country co = business.GetCountryByCode(id);
            return View(co);
        }

        [HttpPost]
        public async Task<IActionResult> EditCountry(string id, [Bind("CountryCode,CountryName,CountryDescription,TimeZone")] Country co)
        {

            if (ModelState.IsValid)
            {

                db.Update(co);
                await db.SaveChangesAsync();
                return RedirectToAction("CRUD");
            }
            return View(co);
        }


        public IActionResult EditOrder(int id)
        {
            Order co = business.GetOrderById(id);
            return View(co);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(int id, [Bind("UserId,ItemId,OrderDate,Quantity,")] Order co)
        {


            if (ModelState.IsValid)
            {
                co.OrderId = id;
                db.Update(co);
                await db.SaveChangesAsync();
                return RedirectToAction("CRUD");
            }
            return View(co);
        }

        public IActionResult CreateUser()
        {
            User user = new User();
                int d;
                List<User> list = business.GetUsers();
                d =list.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                d++;
                user.Id = d;
            user.Username = "NewUser" + d;
            db.Add(user);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }

        public IActionResult CreateDeal()
        {
            GoodDeal Deal = new GoodDeal();
            int d;
            List<GoodDeal> list = business.GetDeals();
            d = list.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            d++;
            Deal.Id = d;
            Deal.ItemName = "new item"+d;
            db.Add(Deal);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }

        public IActionResult CreateCountry()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateCountry([Bind("CountryCode,CountryName,CountryDescription,TimeZone")] Country co)
        {

            if (ModelState.IsValid)
            {

                db.Add(co);
                await db.SaveChangesAsync();
                return RedirectToAction("CRUD");
            }
            return View(co);
        }





        public IActionResult CreateOrder()
        {


            Order o = new Order();
            int d = 0; 
            List<Order> list = business.GetOrders();
            d = list.OrderByDescending(u => u.OrderId).FirstOrDefault().OrderId;
            d++;
            o.OrderId = d;
            o.ItemId = 0;
            o.UserId = 0;
            o.OrderDate = DateTime.Now;
            o.Quantity = 2;
            db.Add(o);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }



        public IActionResult CreateConcert()
        {


            Concert o = new Concert();
            int d;
            List<Concert> list = business.GetConcerts();
            d = list.OrderByDescending(u => u.ConcertId).FirstOrDefault().ConcertId;
            d++;
            o.ConcertId = d;
            o.CountryCode = "BG";
            o.Name = "NewConcert"+d;
            db.Add(o);
            db.SaveChanges();

            return RedirectToAction("CRUD");
        }


    }
}
