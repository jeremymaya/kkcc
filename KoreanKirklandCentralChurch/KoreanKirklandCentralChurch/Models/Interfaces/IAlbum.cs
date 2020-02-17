using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Interfaces
{
    public interface IAlbum
    {
        Task CreateAlbumAsync(Album album);

        Task<Album> GetAlbumByIdAsync(int? id);

        Task<IList<Album>> GetAlbumsAsync();

        Task UpdateAlbumAsync(Album album);

        Task DeleteAlbumAsync(int? id);
    }
}
