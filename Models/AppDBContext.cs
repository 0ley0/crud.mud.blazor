using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.mud.blazor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace crud.mud.blazor.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
        {
            
        }
        public DbSet<Books>books { get; set; }
    }
}