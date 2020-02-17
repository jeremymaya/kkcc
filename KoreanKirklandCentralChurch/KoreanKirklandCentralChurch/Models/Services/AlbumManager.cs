using KoreanKirklandCentralChurch.Data;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Services
{
    public class AlbumManager : IAlbum
    {
        /// <summary>
        /// Establishes a prviate connection to a database via dependency injection
        /// </summary>
        private readonly ChurchDbContext _context;

        public AlbumManager(ChurchDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create - saves an album data by saving an Album object into the connected database
        /// </summary>
        /// <param name="album">Album object containing new album data</param>
        /// <returns></returns>
        public async Task CreateAlbumAsync(Album album)
        {
            await _context.Album.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Read - gets an album data based on the album Id from the connected database
        /// </summary>
        /// <param name="id">album Id</param>
        /// <returns>Album data that matches with the album Id from the connected database</returns>
        public async Task<Album> GetAlbumByIdAsync(int? id) => await _context.Album.FirstOrDefaultAsync(album => album.Id == id);

        /// <summary>
        /// Read - gets all album data from the connected database
        /// </summary>
        /// <returns>IList of album data from the connected database</returns>
        public async Task<IList<Album>> GetAlbumsAsync() => await _context.Album.ToListAsync();

        /// <summary>
        /// Update - modifies an album data from the connected database
        /// </summary>
        /// <param name="album">Album object containing updated album data</param>
        /// <returns></returns>
        public async Task UpdateAlbumAsync(Album album)
        {
            _context.Album.Update(album);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete - removes an album data from the connected database
        /// </summary>
        /// <param name="id">Album Id</param>
        /// <returns></returns>
        public async Task DeleteAlbumAsync(int id)
        {
            Album album = await GetAlbumByIdAsync(id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
        }

    }
}
