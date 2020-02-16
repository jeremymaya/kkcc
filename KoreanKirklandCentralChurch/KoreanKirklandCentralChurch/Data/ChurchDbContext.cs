using KoreanKirklandCentralChurch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Data
{
    public class ChurchDbContext : DbContext
    {
        /// <summary>
        /// ChurchDbContext class constructor requiring the DbContextOptions
        /// </summary>
        /// <param name="options"></param>
        public ChurchDbContext(DbContextOptions<ChurchDbContext> options) : base(options)
        {

        }

        public DbSet<Sermon> Sermon { get; set; }
        public DbSet<Album> Album { get; set; }
    }
}
