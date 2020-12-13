using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.Core;

namespace RestaurantApp.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {

        public Restaurant Restaurant { get; set; }
        public void OnGet()
        {
            Restaurant = new Restaurant();

        }
    }
}