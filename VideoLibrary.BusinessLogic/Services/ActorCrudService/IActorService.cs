using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.ActorCrudService
{
    public interface IActorService
    {
        Task<List<Actor>> GetActors();

        Task<List<Actor>> GetActors(Gender gender);

        Task SaveActor(Actor model);
    }
}
