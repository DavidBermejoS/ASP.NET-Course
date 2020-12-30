using System.Collections.Generic;
using System.Text;
using RestaurantApp.Core;

namespace RestaurantApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(int id);

        int GetCountOfRestaurants();
        int Commit();
    }
}
