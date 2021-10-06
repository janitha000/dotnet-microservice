using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Repositories
{
    public interface IPlatformRepository
    {
        bool SaveChanges();

        Task<IEnumerable<Platform>> GetAllPlatforms();
        Task<Platform> GetPlatformById(int id);

        Task CreatePlatform(Platform platform);
    }
}
