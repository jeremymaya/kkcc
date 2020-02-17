using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreanKirklandCentralChurch.Data;
using KoreanKirklandCentralChurch.Models;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoreanKirklandCentralChurch.Pages.Admin.Albums
{
    public class EditModel : PageModel
    {
        private readonly IAlbum _album;

        public EditModel(IAlbum album)
        {
            _album = album;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _album.UpdateAlbumAsync(Album);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AlbumExists(Album.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> AlbumExists(int id)
        {
            Album album = await _album.GetAlbumByIdAsync(id);
            if (album != null)
            {
                return true;
            }
            return false;
        }
    }
}