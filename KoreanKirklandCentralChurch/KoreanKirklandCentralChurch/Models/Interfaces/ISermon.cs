using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Interfaces
{
    public interface ISermon
    {
        Task CreateSermonAsync(Sermon sermon);

        Task<Sermon> GetSermonByIdAsync(int? id);

        Task<Sermon> GetLatestSermonAsync();

        Task<IList<Sermon>> GetSemonsAsync();

        Task UpdateSermonAsync(Sermon sermon);

        Task DeleteSermonAsync(int? id);
    }
}
