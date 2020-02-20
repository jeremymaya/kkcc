using System;
using KoreanKirklandCentralChurch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KoreanKirklandCentralChurch.Data
{
    public class ChurchApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ChurchApplicationDbContext(DbContextOptions<ChurchApplicationDbContext> options) : base(options)
        {

        }
    }
}
