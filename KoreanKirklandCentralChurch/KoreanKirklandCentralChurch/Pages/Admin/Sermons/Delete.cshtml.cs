using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreanKirklandCentralChurch.Models;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoreanKirklandCentralChurch.Pages.Admin.Sermons
{
    public class DeleteModel : PageModel
    {
        private readonly ISermon _sermon;

        public DeleteModel(ISermon sermon)
        {
            _sermon = sermon;
        }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sermon = await _sermon.GetSermonByIdAsync(id);

            if (Sermon != null)
            {
                await _sermon.DeleteSermonAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
