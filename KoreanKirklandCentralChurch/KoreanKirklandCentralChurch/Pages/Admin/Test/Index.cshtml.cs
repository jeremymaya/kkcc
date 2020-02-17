using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoreanKirklandCentralChurch.Data;
using KoreanKirklandCentralChurch.Models;

namespace KoreanKirklandCentralChurch.Pages.Admin.Test
{
    public class IndexModel : PageModel
    {
        private readonly KoreanKirklandCentralChurch.Data.ChurchDbContext _context;

        public IndexModel(KoreanKirklandCentralChurch.Data.ChurchDbContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }

        public async Task OnGetAsync()
        {
            Album = await _context.Album.ToListAsync();
        }
    }
}
