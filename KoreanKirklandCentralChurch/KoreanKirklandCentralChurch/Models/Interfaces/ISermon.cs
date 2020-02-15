using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Interfaces
{
    interface ISermon
    {
        Task CreateSermonAsync(Sermon sermon);

        Task GetSermonByIdAsync(int id);

        Task<IList<Sermon>> GetSemonsAsync();

        Task UpdateSermonAsync(Sermon sermon);

        Task DeleteSermonAsync(int id);
    }
}
