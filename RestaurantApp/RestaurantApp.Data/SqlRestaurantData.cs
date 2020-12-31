using System.Collections.Generic;
using RestaurantApp.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantAppDbContext db;

        public SqlRestaurantData(RestaurantAppDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            db.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
           return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
