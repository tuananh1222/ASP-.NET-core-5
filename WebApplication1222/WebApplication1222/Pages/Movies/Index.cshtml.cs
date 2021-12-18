using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1222.Data;
using WebApplication1222.Models;

namespace WebApplication1222.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1222.Data.WebApplication1222Context _context;

        public IndexModel(WebApplication1222.Data.WebApplication1222Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
