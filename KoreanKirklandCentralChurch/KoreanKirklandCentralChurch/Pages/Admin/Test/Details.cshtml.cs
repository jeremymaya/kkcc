using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoreanKirklandCentralChurch.Data;
using KoreanKirklandCentralChurch.Models;

namespace KoreanKirklandCentralChurch
{
    public class DetailsModel : PageModel
    {
        private readonly KoreanKirklandCentralChurch.Data.ChurchDbContext _context;

        public DetailsModel(KoreanKirklandCentralChurch.Data.ChurchDbContext context)
        {
            _context = context;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album.FirstOrDefaultAsync(m => m.Id == id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
