using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantApp.Core;
using RestaurantApp.Data;

namespace RestaurantApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public string Message_properties { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                            IRestaurantData restaurantData,
                            ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogInformation("[INFO LOGGER] --> Executing List Model");
            //Message = "Hello World!";
            //Message_properties = config["Message"]; 
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
            logger.LogInformation("[INFO LOGGER] --> Restaurants obtained in db:");
            foreach (Restaurant r in Restaurants.ToList())
            {
                logger.LogInformation("[INFO LOGGER]--> Restaurant nº" + r.Id + "{ Name: " + r.Name + "; Location: " + r.Location + "; Cuisine: " + r.Cuisine + "}");
            }

        }
    }
}
