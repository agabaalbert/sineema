using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ActorRepository
{
    public class ActorRepository : RepositoryBase<LibraryContext>, IActorRepository
    {
        public async Task<List<Actor>> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return await db.Actors.ToListAsync();
            }
        }

        public async Task<List<Actor>> GetAll(Gender gender)
        {
            using(var db = new LibraryContext())
            {
                return await db.Actors.Where(x => x.Gender == gender).ToListAsync();
            }
        }
    }
}
