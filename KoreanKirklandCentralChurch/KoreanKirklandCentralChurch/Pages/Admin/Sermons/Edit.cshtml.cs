using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreanKirklandCentralChurch.Models;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoreanKirklandCentralChurch.Pages.Admin.Sermons
{
    public class EditModel : PageModel
    {
        private readonly ISermon _sermon;

        public EditModel(ISermon sermon)
        {
            _sermon = sermon;
        }

        [BindProperty]
        public Sermon Sermon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sermon = await _sermon.GetSermonByIdAsync(id);

            if (Sermon == null)
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
                await _sermon.UpdateSermonAsync(Sermon);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SermonExists(Sermon.Id))
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

        private async Task<bool> SermonExists(int id)
        {
            Sermon sermon = await _sermon.GetSermonByIdAsync(id);
            if (sermon != null)
            {
                return true;
            }
            return false;
        }
    }
}
