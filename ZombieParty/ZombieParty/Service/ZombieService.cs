using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Service
{
    public class ZombieService: ServiceBaseAsync<Zombie>, IZombieService
    {
        public ZombieService(ZombiePartyDbContext _context): base(_context)
        {
            
        }
        public async Task<IEnumerable<Zombie>> GetAllZombieTypeAsync(int zombieTypeId)
        {
            return await _dbContext.Zombies.Where(z => z.ZombieTypeId == zombieTypeId).ToListAsync();
        }

        
    }
}
