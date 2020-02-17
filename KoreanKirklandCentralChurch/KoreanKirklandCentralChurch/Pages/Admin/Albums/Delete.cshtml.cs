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
    public class DeleteModel : PageModel
    {
        private readonly IAlbum _album;

        public DeleteModel(IAlbum album)
        {
            _album = album;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _album.GetAlbumByIdAsync(id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _album.GetAlbumByIdAsync(id);

            if (Album != null)
            {
                await _album.DeleteAlbumAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}