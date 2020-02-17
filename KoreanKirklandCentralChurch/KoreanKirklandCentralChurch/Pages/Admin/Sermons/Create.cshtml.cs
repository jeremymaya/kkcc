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
    public class CreateModel : PageModel
    {
        private readonly ISermon _sermon;

        public CreateModel(ISermon sermon)
        {
            _sermon = sermon;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sermon Sermon { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _sermon.CreateSermonAsync(Sermon);

            return RedirectToPage("./Index");
        }
    }
}