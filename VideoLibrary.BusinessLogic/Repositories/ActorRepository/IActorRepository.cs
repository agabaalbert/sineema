using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ActorRepository
{
    public interface IActorRepository : IRepositoryBase
    {
        Task<List<Actor>> GetAll();

        Task<List<Actor>> GetAll(Gender gender);
    }
}
