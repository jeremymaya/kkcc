using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreanKirklandCentralChurch.Models;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoreanKirklandCentralChurch.Pages.Admin.Albums
{
    public class CreateModel : PageModel
    {
        private readonly IAlbum _album;

        public CreateModel(IAlbum album)
        {
            _album = album;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _album.CreateAlbumAsync(Album);

            return RedirectToPage("./Index");
        }
    }
}