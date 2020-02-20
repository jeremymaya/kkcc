using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KoreanKirklandCentralChurch.Models
{
    public class ApplicationUser : IdentityUser
    {

    }

    /// <summary>
    /// Creates Admin role
    /// </summary>
    public static class ApplicationRoles
    {
        public const string Admin = "Administrator";
    }
}
