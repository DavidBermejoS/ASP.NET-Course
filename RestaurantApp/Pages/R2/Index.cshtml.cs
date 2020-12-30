using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Core;
using RestaurantApp.Data;

namespace RestaurantApp.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantAppDbContext _context;

        public IndexModel(RestaurantApp.Data.RestaurantAppDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
