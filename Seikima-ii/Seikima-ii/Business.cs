using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Seikima_ii.Data;
using Seikima_ii.Models;
namespace Seikima_ii
{
    public class Business
    {
      
        SeikimatsuContext db;
        public Business(SeikimatsuContext context)
        {
            db = context;
        }

        #region user
        public User GetUserByUsername(string username)
        {
            User? user = db.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return (NullUser());
            return user;
        }
        public User NullUser()
        {
            User user = new User();
            user.Id = 0;
            user.Fname = string.Empty;
            user.Lname = string.Empty;
            user.UserImg = string.Empty;
            user.Username = string.Empty;
            user.Password = string.Empty;
            return user;
        }

        public User GetUserById(int id)
        {
            User user = db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void DeleteUserById(int id)
        {
            db.Users.Remove(GetUserById(id));
            db.SaveChanges();
        }


        public void AddUser(User user)
        {
            //validation: checks if there is a user with the same name
            User? existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser == null)
            {
                user.Fname = string.Empty;
                user.Lname = string.Empty;
                user.UserImg = string.Empty;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = db.Users.ToList();
            //users.RemoveAt(0); //This removes the new User
            return users;
        }
        #endregion


        public GoodDeal GetDealById(int id)
        {
            GoodDeal user = db.GoodDeals.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void DeleteDealById(int id)
        {
            db.GoodDeals.Remove(GetDealById(id));
            db.SaveChanges();
        }

        public List<GoodDeal> GetDeals()
        {
            List<GoodDeal> deals = new List<GoodDeal>();
            deals = db.GoodDeals.ToList();
            return deals;
        }

        public List<Concert> GetConcerts()
        {

            List<Concert> deals = new List<Concert>();
            deals = db.Concerts.ToList();
            return deals;

        }

   


        public Order GetOrderById(int id)
        {
            Order o = db.Orders.FirstOrDefault(u => u.OrderId == id);
            return o;
        }

        public void DeleteOrderById(int id)
        {
            db.Orders.Remove(GetOrderById(id));
            db.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            orders = db.Orders.ToList();
            return orders;
        }

        public List<Order> GetOrdersWithId(int id)
        {
            List<Order> orders = new List<Order>();
            orders = db.Orders.ToList();
            orders.RemoveAll(o => o.UserId != id);
            return orders;
        }





        public Country GetCountryByCode(string Code)
        {
            Country o = db.Countries.FirstOrDefault(u => u.CountryCode == Code);
            return o;
        }
        public void DeleteCountryById(string Code)
        {

            db.Countries.Remove(GetCountryByCode(Code));
            db.SaveChanges();
        }


        public List<Country> getCountries()
        {
            List<Country> country = new List<Country>();
            country = db.Countries.ToList();
            return country;
        }




        public Concert GetConsertByid(int id)
        {
            Concert o = db.Concerts.FirstOrDefault(u => u.ConcertId == id);
            return o;
        }
        public void DeleteCounsetyById(int id)
        {

            db.Concerts.Remove(GetConsertByid(id));
            db.SaveChanges();
        }


        public List<Concert> getCousert()
        {
            List<Concert> c = new List<Concert>();
            c = db.Concerts.ToList();
            return c;
        }



    }
}
