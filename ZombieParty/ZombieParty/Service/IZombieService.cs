using ZombieParty.Models;

namespace ZombieParty.Service
{
    public interface IZombieService : IServiceBaseAsync<Zombie>
    {
        Task<IEnumerable<Zombie>> GetAllZombieTypeAsync(int zombieTypeId);
    }
}
