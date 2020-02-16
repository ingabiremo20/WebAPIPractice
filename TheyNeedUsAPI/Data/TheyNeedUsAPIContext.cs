using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheyNeedUsAPI.Models;

    public class TheyNeedUsAPIContext : DbContext
    {
        public TheyNeedUsAPIContext (DbContextOptions<TheyNeedUsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Posts> Posts { get; set; }
    }
