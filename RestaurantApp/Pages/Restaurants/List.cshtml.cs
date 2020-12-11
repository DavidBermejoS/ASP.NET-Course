using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestaurantApp.Data;

namespace RestaurantApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }

        public string Message_properties { get; set; }


        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
        }

        public void OnGet()
        {
            Message = "Hello World!";
            Message_properties = config["Message"];
        }
    }
}
