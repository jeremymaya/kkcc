using KoreanKirklandCentralChurch.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models.Services
{
    public class SermonManager : ISermon
    {
        public Task CreateSermonAsync(Sermon sermon)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSermonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Sermon>> GetSemonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetSermonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSermonAsync(Sermon sermon)
        {
            throw new NotImplementedException();
        }
    }
}
