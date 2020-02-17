using KoreanKirklandCentralChurch.Data;
using KoreanKirklandCentralChurch.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Services
{
    public class SermonManager : ISermon
    {
        /// <summary>
        /// Establishes a prviate connection to a database via dependency injection
        /// </summary>
        private readonly ChurchDbContext _context;

        public SermonManager(ChurchDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create - saves a sermon data by saving a Sermon object into the connected database
        /// </summary>
        /// <param name="sermon">Sermon object containing new sermon data</param>
        /// <returns></returns>
        public async Task CreateSermonAsync(Sermon sermon)
        {
            await _context.Sermon.AddAsync(sermon);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Read - gets a sermon data based on the sermon Id from the connected database
        /// </summary>
        /// <param name="id">Sermon Id</param>
        /// <returns>Sermon data that matches with the sermon Id from the connected database</returns>
        public async Task<Sermon> GetSermonByIdAsync(int id) => await _context.Sermon.FirstOrDefaultAsync(sermon => sermon.Id == id);

        public async Task<Sermon> GetLatestSermonAsync()
        {
            IList<Sermon> sermons = await GetSemonsAsync();
            return sermons.OrderByDescending(sermon => sermon.Id).FirstOrDefault();
        }

        /// <summary>
        /// Read - gets all sermon data from the connected database
        /// </summary>
        /// <returns>IList of sermon data from the conneceted database</returns>
        public async Task<IList<Sermon>> GetSemonsAsync() => await _context.Sermon.ToListAsync();

        /// <summary>
        /// Update - modifies a sermon data from the connected database
        /// </summary>
        /// <param name="sermon">Sermon object containing updated sermon data</param>
        /// <returns></returns>
        public async Task UpdateSermonAsync(Sermon sermon)
        {
            _context.Sermon.Update(sermon);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete - removes a sermon data from the connected database
        /// </summary>
        /// <param name="id">Sermon Id</param>
        /// <returns></returns>
        public async Task DeleteSermonAsync(int id)
        {
            Sermon sermon = await GetSermonByIdAsync(id);
            _context.Sermon.Remove(sermon);
            await _context.SaveChangesAsync();
        }
    }
}
