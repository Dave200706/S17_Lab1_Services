using Microsoft.Build.ObjectModelRemoting;
using Microsoft.Identity.Client;
using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Service
{
    public class ZombieTypeService: ServiceBaseAsync<ZombieType>, IZombieTypeService
    {
        /*Ici, on passe le DbContext au constructeur de la classe parente ServiceBaseAsync avec base. C'est nécessaire, parce que la classe ZombieTypeService hérite de ServiceBaseAsync qui a une le context en paramètre*/
        public ZombieTypeService(ZombiePartyDbContext dbContext): base(dbContext) { }
        public bool HasAssociatedZombies(int id)
        {
            var associateZombie = _dbContext.Zombies.Where(x => x.ZombieTypeId == id).Any();
            return associateZombie;
        }
        public override async Task DeleteAsync(int id)
        {
            var zombieType = await this.GetByIdAsync(id);
            if (zombieType == null)
                return;
            if (HasAssociatedZombies(id)) //Si zombi est assicier, on le rend indisponible
            {
                zombieType.IsDisponible = false;
                await this.EditAsync(zombieType);
            }
            else     //Sinon on suprime un zombie
            {           
                await base.DeleteAsync(id);
            }
        }
    }
}
