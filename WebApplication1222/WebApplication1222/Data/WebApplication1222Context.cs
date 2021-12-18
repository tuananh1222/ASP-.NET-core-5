using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1222.Models;

namespace WebApplication1222.Data
{
    public class WebApplication1222Context : DbContext
    {
        public WebApplication1222Context (DbContextOptions<WebApplication1222Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1222.Models.Movie> Movie { get; set; }
    }
}
