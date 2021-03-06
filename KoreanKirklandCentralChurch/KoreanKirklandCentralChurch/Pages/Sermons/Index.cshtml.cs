using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreanKirklandCentralChurch.Models;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoreanKirklandCentralChurch.Pages.Sermons
{
    public class IndexModel : PageModel
    {
        private readonly ISermon _sermon;

        public IndexModel(ISermon sermon)
        {
            _sermon = sermon;
        }

        public IList<Sermon> Sermons { get; set; }

        public async Task OnGetAsync()
        {
            Sermons = await _sermon.GetSemonsAsync();
        }
    }
}
