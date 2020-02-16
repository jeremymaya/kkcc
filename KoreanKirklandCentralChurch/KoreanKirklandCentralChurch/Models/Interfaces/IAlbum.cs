using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Interfaces
{
    interface IAlbum
    {
        Task CreateAlbumAsync(Sermon sermon);

        Task<Sermon> GetAlbumByIdAsync(int id);

        Task<IList<Sermon>> GetAlbumsAsync();

        Task UpdateAlbumAsync(Sermon sermon);

        Task DeleteAlbumAsync(int id);
    }
}
