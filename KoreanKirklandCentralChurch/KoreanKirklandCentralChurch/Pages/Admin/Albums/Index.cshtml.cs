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
    public class IndexModel : PageModel
    {
        private readonly IAlbum _album;

        public IndexModel(IAlbum album)
        {
            _album = album;
        }

        public IList<Album> Albums { get; set; }

        public async Task OnGetAsync()
        {
            Albums = await _album.GetAlbumsAsync();
        }
    }
}
