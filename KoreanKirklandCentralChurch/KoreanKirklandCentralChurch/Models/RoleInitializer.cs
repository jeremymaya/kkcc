using System;
using System.Collections.Generic;
using System.Linq;
using KoreanKirklandCentralChurch.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KoreanKirklandCentralChurch.Models
{
    public class RoleInitializer
    {
        /// <summary>
        /// Creates Roles List to store IdentityRoles
        /// </summary>
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole { Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
        };

        /// <summary>
        /// Seeds the Roles data into the ApplicationDbContext
        /// Adds Roles data by calling AddRoles() method
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ChurchApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChurchApplicationDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        /// <summary>
        /// Adds IdentityRoles in Roles to the ApplicationDbContext and save the changes
        /// </summary>
        /// <param name="dbContext">ApplicationUserDbContext</param>
        private static void AddRoles(ChurchApplicationDbContext dbContext)
        {
            if (dbContext.Roles.Any())
                return;

            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
    }
}
